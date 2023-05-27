using Lesson5Singleton.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5Singleton.Scripts.Systems
{
    public class CameraFollower : MonoBehaviour, IGameLateUpdateListener
    {
        [SerializeField]
        private Camera targetCamera;

        [SerializeField]
        // private Player _player;
         private PlayerService _playerService;

        [SerializeField]
        private Vector3 offset;
        
        
        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            //this.targetCamera.transform.position = _player.GetPosition() + this.offset;
            this.targetCamera.transform.position = _playerService.GetPlayer().GetPosition() + this.offset;
        }
    }
}