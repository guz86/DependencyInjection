using Lesson6TeacherZenject.Scripts.App;
using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.Game
{
    [AddComponentMenu("Lesson6/GameTimerController")]
    public sealed class GameTimerController : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        private GameTimer _gameTimer;

        private void Awake()
        {
            _gameTimer = GameTimer.Instance;
        }

        public void OnGameStarted()
        {
            _gameTimer.Start();
        }

        public void OnGameFinished()
        {
            _gameTimer.Stop();
            
            SaveRepository.SaveValue("last_time", _gameTimer.Time);
        }
    }
}