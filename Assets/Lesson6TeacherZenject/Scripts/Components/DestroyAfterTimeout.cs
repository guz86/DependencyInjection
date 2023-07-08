using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.Components
{
    [AddComponentMenu("Lesson6/DestroyAfterTimeout")]
    public sealed class DestroyAfterTimeout : MonoBehaviour
    {
        [SerializeField]
        private float _timeout = 3f;

        private float _time;

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _timeout)
            {
                Destroy(gameObject);
            }
        }
    }
}