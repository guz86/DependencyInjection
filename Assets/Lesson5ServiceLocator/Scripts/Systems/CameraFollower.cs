using Lesson5ServiceLocator.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5ServiceLocator.Scripts.Systems
{
    public class CameraFollower : MonoBehaviour, IGameLateUpdateListener
    {
        [SerializeField] private Camera targetCamera;

        //[SerializeField] 
        // private Player _player;
        // private PlayerService _playerService;

        [SerializeField] private Vector3 offset;
        
        
        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            //this.targetCamera.transform.position = _player.GetPosition() + this.offset;
            //this.targetCamera.transform.position = _playerService.GetPlayer().GetPosition() + this.offset;
            // this.targetCamera.transform.position = PlayerService.Instance
            //     .GetPlayer()
            //     .GetPosition() + this.offset;
            
            this.targetCamera.transform.position = ServiceLocator.GetService<PlayerService>()
                .GetPlayer()
                .GetPosition() + this.offset;
        }
    }
}