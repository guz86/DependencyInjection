using UnityEngine;

namespace Lesson5DI3
{
    [RequireComponent(typeof(GameSystem))]
    public sealed class GameInstaller : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _services;

        private GameSystem _gameSystem;

        private void Awake()
        {
            _gameSystem = GetComponent<GameSystem>();
            InstallServices();
            InstallListeners();
            ResolveDependencies(transform);
        }
        
        private void InstallServices()
        {
            foreach (var service in _services)
            {
                _gameSystem.AddService(service);
            }
        }
        
        private void InstallListeners()
        {
             var listeners = this.GetComponentsInChildren<IGameListener>();

            foreach (var listener in listeners)
            {
                _gameSystem.AddListener(listener);
            }
        }
 
        private void ResolveDependencies(Transform node)
        {
            var behaviours = node.GetComponents<MonoBehaviour>();

            foreach (var behaviour in behaviours)
            {
                _gameSystem.Inject(behaviour);
            }

            foreach (Transform child in node)
            {
                ResolveDependencies(child);
            }
        }
    }
}