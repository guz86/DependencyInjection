using Lesson6TeacherZenject.Scripts.Architecture;
using Lesson6TeacherZenject.Scripts.UI;
using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.Game
{
    public sealed class GameOverScreenController : MonoBehaviour, IInitializeGameListener, IFinishGameListener
    {
        [SerializeField]
        private GameOverScreen _gameOverScreen;

        private GameTimer _gameTimer;

        private void Awake()
        {
            _gameTimer = GameTimer.Instance;
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