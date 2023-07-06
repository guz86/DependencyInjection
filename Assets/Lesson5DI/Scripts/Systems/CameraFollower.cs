using UnityEngine;

namespace Lesson5DI
{
    public class CameraFollower : MonoBehaviour,
        //IGameInitListener, 
        IGameLateUpdateListener
    {
        [SerializeField] private Camera targetCamera;

        [SerializeField] private Vector3 offset;

        private IPlayerService _playerService;

        //[Inject]
        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // void IGameInitListener.OnInit()
        // {
        //     _playerService = ServiceLocator.GetService<IPlayerService>();
        // }

        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            this.targetCamera.transform.position = _playerService
                .GetPlayer()
                .GetPosition() + this.offset;
        }
    }
}