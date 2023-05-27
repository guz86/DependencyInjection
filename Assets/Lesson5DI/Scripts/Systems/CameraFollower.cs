using Lesson5DI.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5DI.Scripts.Systems
{
    public class CameraFollower : MonoBehaviour, 
        IGameInitListener, 
        IGameLateUpdateListener
    {
        [SerializeField] private Camera targetCamera;

        [SerializeField] private Vector3 offset;

        private IPlayerService _playerService;
        
        void IGameInitListener.OnInit()
        {
            _playerService = ServiceLocator.GetService<IPlayerService>();
        }

        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            // this.targetCamera.transform.position = ServiceLocator.GetService<PlayerService>()
            //     .GetPlayer()
            //     .GetPosition() + this.offset;
            this.targetCamera.transform.position = _playerService
                .GetPlayer()
                .GetPosition() + this.offset;
        }

        
    }
}