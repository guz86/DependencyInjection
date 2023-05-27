
using UnityEngine;

namespace Lesson5DI
{
    public sealed class DependencyResolver : MonoBehaviour
    {
        [SerializeField] private CameraFollower _cameraFollower;
        [SerializeField] private MoveController _moveController;

        // init на gameManager вызывать не нужно
        private void Start()
        {
            var playerService = ServiceLocator.GetService<IPlayerService>();
            var keyboardInput = ServiceLocator.GetService<KeyboardInput>();
            
            _cameraFollower.Construct(playerService);
            _moveController.Construct(keyboardInput, playerService); 
        }
    }
}