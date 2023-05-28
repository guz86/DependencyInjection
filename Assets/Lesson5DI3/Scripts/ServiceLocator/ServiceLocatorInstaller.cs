
using UnityEngine;

namespace Lesson5DI3
{
    public sealed class ServiceLocatorInstaller : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _services;
        
        
        private void Awake()
        {
            foreach (var service in _services)
            {
                ServiceLocator.AddService(service);
            }
        }
    }
}