using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts
{
    [AddComponentMenu("Lesson6/Projectile")]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField]
        private int _damage = 1;

        [SerializeField]
        private float _attackDistance = 1;

        [SerializeField]
        private float _speed = 8;
        
        private Player _player;
        private Pool _pool;

        [Inject]
        private void Constract(Player player, Pool pool)
        {
            _player = player;
            _pool = pool;
        }
        
        
        // private void Awake()
        // {
        //     //_player = Player.Instance;
        //     _player = FindObjectOfType<Player>();
        // }
        
        private void Update()
        {
            if (_player == null)
            {
                //Destroy(gameObject);
                _pool.Despawn(this);
                return;
            }
            
            var direction = _player.transform.position - transform.position;
           
            if (direction.magnitude <= _attackDistance)
            {
                _player.TakeDamage(_damage);
                //Destroy(gameObject);
                _pool.Despawn(this);
            }
            else
            {
                transform.LookAt(_player.transform.position);

                var movement = _speed * Time.deltaTime * direction.normalized;
                transform.position += movement;
            }
        }
        
        public sealed class Pool : MonoMemoryPool<Vector3, Projectile>
        {
            protected override void Reinitialize(Vector3 position, Projectile projectile)
            {
                projectile.transform.position = position;
            }
        }
    }
}