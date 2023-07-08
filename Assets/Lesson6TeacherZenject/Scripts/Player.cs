using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lesson6TeacherZenject.Scripts
{
    [AddComponentMenu("Lesson6/Player")]
    [DefaultExecutionOrder(-100)]
    public sealed class Player : MonoBehaviour
    {
        //public static Player Instance { get; private set; }
        
        public event Action<int> HealthChanged;
        public event Action Destroyed;
        
        public int Health => _health;
        
        [SerializeField]
        private int _health = 5;

        [SerializeField]
        private float _speed = 10;

        private CharacterController _characterController;

        private void Awake()
        {
            // if (Instance != null)
            // {
            //     Destroy(this);
            // }
            // else
            // {
            //     Instance = this;

                _characterController = GetComponent<CharacterController>();
         //   }
        }
        
        private void Update()
        {
            var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            movement *= _speed * Time.deltaTime;

            _characterController.Move(movement);
        }
        
        [Button]
        public void TakeDamage(int damage)
        {
            _health = Mathf.Max(_health - damage, 0);
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
            {
                Destroy(gameObject);
                Destroyed?.Invoke();
            }
        }
    }
}