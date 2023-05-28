using UnityEngine;
using UnityEngine.Serialization;

namespace Lesson5DI3
{
    [RequireComponent(typeof(GameSystem))]
    public sealed class GameInstaller : MonoBehaviour
    {
        //[SerializeField] private MonoBehaviour[] _services;
        [SerializeField] private GameModule[] _modules;

        private GameSystem _gameSystem;

        private void Awake()
        {
            _gameSystem = GetComponent<GameSystem>();
            InstallServices();
            InstallListeners();
            ResolveDependencies();
        }
        
        private void InstallServices()
        {
            foreach (var module in _modules)
            {
                var services = module.GetServices();
                _gameSystem.AddServices(services);
            }
        }
        
        private void InstallListeners()
        {
             //var listeners = this.GetComponentsInChildren<IGameListener>();

            foreach (var _module in _modules)
            {
                var listeners = _module.GetListeners();
                _gameSystem.AddListeners(listeners);
            }
        }
 
        private void ResolveDependencies()
        {
            foreach (var module in _modules)
            {
                module.ResolveDependencies(_gameSystem);
            }
        }
    }
}