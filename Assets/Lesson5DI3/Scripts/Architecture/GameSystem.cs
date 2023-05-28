using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lesson5DI3
{
    public sealed class GameSystem : MonoBehaviour
    {
        [SerializeField] private bool _autoRun = true;


        public GameSystem()
        {
            _injector = new GameInjector(_serviceLocator);
        }

        #region GameListeners

        [ShowInInspector, ReadOnly]
        public GameState State
        {
            get { return _gameMachine.State; }
        }

        private readonly GameMachine _gameMachine = new GameMachine();

        private void Start()
        {
            if (_autoRun)
            {
                //InitGame();
                StartGame();
            }
        }


        private void Update()
        {
            _gameMachine.Update();
        }

        private void FixedUpdate()
        {
            _gameMachine.FixedUpdate();
        }

        private void LateUpdate()
        {
            _gameMachine.LateUpdate();
        }


        public void AddListener(IGameListener listener)
        {
            _gameMachine.AddListener(listener);
        }
        
        public void AddListeners(IEnumerable<IGameListener> listeners)
        {
            _gameMachine.AddListeners(listeners);
        }

        public void RemoveListener(IGameListener listener)
        {
            _gameMachine.RemoveListener(listener);
        }

        [Button]
        public void InitGame()
        {
            _gameMachine.InitGame();
        }

        [Button]
        public void StartGame()
        {
            _gameMachine.StartGame();
        }

        [Button]
        public void PauseGame()
        {
            _gameMachine.PauseGame();
        }

        [Button]
        public void ResumeGame()
        {
            _gameMachine.ResumeGame();
        }

        [Button]
        public void FinishGame()
        {
            _gameMachine.FinishGame();
        }

        #endregion

        #region ServiceLocator

        private readonly GameLocator _serviceLocator = new GameLocator();

        public List<T> GetServices<T>()
        {
            return _serviceLocator.GetServices<T>();
        }

        public object GetService(Type serviceType)
        {
            return _serviceLocator.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return _serviceLocator.GetService<T>();
        }

        public void AddService(object service)
        {
            _serviceLocator.AddService(service);
        }

        public void AddServices(IEnumerable<object> services)
        {
            _serviceLocator.AddServices(services);
        }


        #endregion

        #region DependencyInjection

        private readonly GameInjector _injector;

        public void Inject(object target)
        {
            _injector.Inject(target);
        }

        #endregion
    }
}