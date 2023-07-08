using Lesson6TeacherZenject.Scripts.Architecture;
using Lesson6TeacherZenject.Scripts.UI;
using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.Game
{
    public sealed class GameOverScreenController :IInitializeGameListener, IFinishGameListener
    {
        
        private readonly GameOverScreen _gameOverScreen;
        private readonly GameTimer _gameTimer;

        // private void Awake()
        // {
        //     _gameTimer = GameTimer.Instance;
        // }

        public GameOverScreenController(GameOverScreen gameOverScreen, GameTimer gameTimer)
        {
            _gameOverScreen = gameOverScreen;
            _gameTimer = gameTimer;
        }

            void IInitializeGameListener.OnGameInitialized()
        {
            _gameOverScreen.Hide();
        }

        void IFinishGameListener.OnGameFinished()
        {
            _gameOverScreen.Show($"Your time is\n{_gameTimer.Time:F1}");
        }
    }
}