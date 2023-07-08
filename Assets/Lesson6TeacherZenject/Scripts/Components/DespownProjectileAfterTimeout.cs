using System;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Components
{
    [AddComponentMenu("Lesson6/DestroyAfterTimeout")]
    public sealed class DespownProjectileAfterTimeout : MonoBehaviour
    {
        [SerializeField]
        private float _timeout = 3f;

        private float _time;

        private Projectile.Pool _pool;
        private Projectile _projectile;

        [Inject]
        private void Construct(Projectile.Pool pool)
        {
            _pool = pool;
        }

        private void Awake()
        {
            _projectile = GetComponent<Projectile>();
        }

        private void OnEnable()
        {
            _time = 0;
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _timeout)
            {
                //Destroy(gameObject);
                _pool.Despawn(_projectile);
            }
        }
    }
}