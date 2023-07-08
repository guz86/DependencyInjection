using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Game
{
    public sealed class PlayerDestroyedObserver : IStartGameListener, IFinishGameListener
    {
        private readonly IGameManager _gameManager;
        private readonly Player _player;

        // [Inject]
        // private void Construct(IGameManager gameManager)
        // {
        //     _gameManager = gameManager;
        // }
        
        
        private PlayerDestroyedObserver(IGameManager gameManager, Player player)
        {
            _gameManager = gameManager;
            _player = player;
        }
        
        // private void Awake()
        // {
        //     //_gameManager = GameManager.Instance;
        //     _player = Player.Instance;
        // }

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