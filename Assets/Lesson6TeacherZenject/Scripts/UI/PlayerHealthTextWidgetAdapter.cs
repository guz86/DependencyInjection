using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.UI
{
    [AddComponentMenu("Lesson6/PlayerHealthTextWidgetAdapter")]
    public sealed class PlayerHealthTextWidgetAdapter : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private TextWidget _textWidget;

        private Player _player;

        // private void Awake()
        // {
        //     _player = Player.Instance;
        // }
        
        [Inject]
        private void Constuct(Player player)
        {
            _player = player;
        }

        void IStartGameListener.OnGameStarted()
        {
            _player.HealthChanged += SetHealth;
            
            SetHealth(_player.Health);
        }

        void IFinishGameListener.OnGameFinished()
        {
            _player.HealthChanged -= SetHealth;
        }

        private void SetHealth(int health)
        {
            _textWidget.SetText(health.ToString());
        }
    }
}