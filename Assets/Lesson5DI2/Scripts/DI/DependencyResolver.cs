using UnityEngine;

namespace Lesson5DI2
{
    public sealed class DependencyResolver : MonoBehaviour
    {
        [SerializeField] private CameraFollower _cameraFollower;
        [SerializeField] private MoveController _moveController;

        // init на gameManager вызывать не нужно
        private void Start()
        {
            DependencyInjector.Inject(_cameraFollower);
            DependencyInjector.Inject(_moveController);
            
            // var playerService = ServiceLocator.GetService<IPlayerService>();
            // var keyboardInput = ServiceLocator.GetService<KeyboardInput>();
            //
            // _cameraFollower.Construct(playerService);
            // _moveController.Construct(keyboardInput, playerService); 
        }
    }
}