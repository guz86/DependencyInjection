using System.Collections;
using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts
{
    [AddComponentMenu("Lesson6/Tower")]
    public sealed class Tower : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private Transform _shootPoint;
        
        [SerializeField]
        private float _minShootTimeout = 0.5f;
    
        [SerializeField]
        private float _maxShootTimeout = 1.5f;

        // [SerializeField]
        // private ProjectileSpawner _projectileSpawner;
        
        private Projectile.Pool _projectilepool;
        
        [Inject]
        private void Construct(Projectile.Pool projectilepool)
        {
            _projectilepool = projectilepool;
        }

        private Vector3 _shootPosition;
        private Coroutine _attackCoroutine;

        void IStartGameListener.OnGameStarted()
        {
            _shootPosition = _shootPoint.position;
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        void IFinishGameListener.OnGameFinished()
        {
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
                _attackCoroutine = null;
            }
        }
        
        private IEnumerator AttackCoroutine()
        {
            while (true)
            {
                var timeout = Random.Range(_minShootTimeout, _maxShootTimeout);
                yield return new WaitForSeconds(timeout);

                //_projectileSpawner.SpawnProjectile(transform, _shootPosition);
                _projectilepool.Spawn(_shootPosition);
            }
        }
    }
}