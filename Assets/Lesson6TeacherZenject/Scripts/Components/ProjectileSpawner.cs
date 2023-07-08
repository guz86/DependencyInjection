using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Components
{
    [AddComponentMenu("Lesson6/ProjectileSpawner")]
    public sealed class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private Projectile _projectilePrefab;

        //private Player _player;
        private DiContainer _container;
        
        // [Inject]
        // public void Constract(Player player)
        // {
        //     _player = player;
        // }
        
        [Inject]
        public void Constract(DiContainer container)
        {
            _container = container;
        }
        
        public Projectile SpawnProjectile(Transform parent, Vector3 position)
        {
            // var projectile = Instantiate(_projectilePrefab, position, Quaternion.identity, parent);
            // projectile.Constract(_player);
            //
            // return projectile;

            return _container.InstantiatePrefabForComponent<Projectile>(_projectilePrefab, position,
                Quaternion.identity, parent);
        }
    }
}