using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.World
{
    public sealed class OutOfBounds : MonoBehaviour
    {
        [SerializeField]
        private int _damage = 9999;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.TakeDamage(_damage);
            }
        }
    }
}