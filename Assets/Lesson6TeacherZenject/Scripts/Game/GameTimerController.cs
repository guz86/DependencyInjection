using Lesson6TeacherZenject.Scripts.App;
using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.Game
{
    [AddComponentMenu("Lesson6/GameTimerController")]
    public sealed class GameTimerController :  IStartGameListener, IFinishGameListener
    {
        private readonly GameTimer _gameTimer;

        // private void Awake()
        // {
        //     _gameTimer = GameTimer.Instance;
        // }

        public GameTimerController(GameTimer gameTimer)
        {
            _gameTimer = gameTimer;
        }
        
        void IStartGameListener.OnGameStarted()
        {
            _gameTimer.Start();
        }

        void IFinishGameListener.OnGameFinished()
        {
            _gameTimer.Stop();
            
            SaveRepository.SaveValue("last_time", _gameTimer.Time);
        }
    }
}