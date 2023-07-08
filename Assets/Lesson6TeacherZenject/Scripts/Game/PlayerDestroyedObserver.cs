using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Game
{
    public sealed class PlayerDestroyedObserver : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        private IGameManager _gameManager;
        private Player _player;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Awake()
        {
            //_gameManager = GameManager.Instance;
            _player = Player.Instance;
        }

        void IStartGameListener.OnGameStarted()
        {
            _player.Destroyed += OnPlayerDestroyed;
        }

        void IFinishGameListener.OnGameFinished()
        {
            _player.Destroyed -= OnPlayerDestroyed;
        }

        private void OnPlayerDestroyed()
        {
            _gameManager.FinishGame();
        }
    }
}