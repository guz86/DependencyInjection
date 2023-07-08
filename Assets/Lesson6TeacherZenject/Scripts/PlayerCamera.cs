using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts
{
    [AddComponentMenu("Lesson6/PlayerCamera")]
    public sealed class PlayerCamera : MonoBehaviour, IInitializeGameListener, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private Vector3 _offset;

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
        
        private void LateUpdate()
        {
            if (_player == null)
            {
                return;
            }
            
            transform.position = _player.transform.position + _offset;
        }

        void IInitializeGameListener.OnGameInitialized()
        {
            SetEnable(false);
        }
        
        void IStartGameListener.OnGameStarted()
        {
            SetEnable(true);
        }

        void IFinishGameListener.OnGameFinished()
        {
            SetEnable(false);
        }

        private void SetEnable(bool value)
        {
            enabled = value;
        }
    }
}