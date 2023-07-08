using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.Components
{
    [AddComponentMenu("Lesson6/ProjectileSpawner")]
    public sealed class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private Projectile _projectilePrefab;

        public Projectile SpawnProjectile(Transform parent, Vector3 position)
        {
            return Instantiate(_projectilePrefab, position, Quaternion.identity, parent);
        }
    }
}