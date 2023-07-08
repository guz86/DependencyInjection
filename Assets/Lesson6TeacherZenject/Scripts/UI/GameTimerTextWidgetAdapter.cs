using Lesson6TeacherZenject.Scripts.Architecture;
using Lesson6TeacherZenject.Scripts.Game;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.UI
{
    [AddComponentMenu("Lesson6/GameTimerTextWidgetAdapter")]
    public sealed class GameTimerTextWidgetAdapter : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private TextWidget _textWidget;

        private GameTimer _gameTimer;
        
        [Inject]
        private void Constuct(GameTimer gameTimer)
        {
            _gameTimer = gameTimer;
        }

        void IStartGameListener.OnGameStarted()
        {
            _gameTimer.Ticked += SetTime;
            
            SetTime(_gameTimer.Time);
        }

        void IFinishGameListener.OnGameFinished()
        {
            _gameTimer.Ticked -= SetTime;
        }

        private void SetTime(float time)
        {
            _textWidget.SetText(time.ToString("F1"));
        }
    }
}