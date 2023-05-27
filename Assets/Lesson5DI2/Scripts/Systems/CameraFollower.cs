
using UnityEngine;

namespace Lesson5DI2
{
    public class CameraFollower : MonoBehaviour, 
        IGameLateUpdateListener
    {
        [SerializeField] private Camera targetCamera;

        [SerializeField] private Vector3 offset;

        private IPlayerService _playerService;

        [Inject]
        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            this.targetCamera.transform.position = _playerService
                .GetPlayer()
                .GetPosition() + this.offset;
        }

        
    }
}