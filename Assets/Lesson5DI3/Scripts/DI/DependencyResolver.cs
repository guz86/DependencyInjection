using UnityEngine;

namespace Lesson5DI3
{
    public sealed class DependencyResolver : MonoBehaviour
    {
        // [SerializeField] private CameraFollower _cameraFollower;
        // [SerializeField] private MoveController _moveController;

        // init на gameManager вызывать не нужно
        private void Start()
        {
            ResolveDependencies(transform);
            
            // DependencyInjector.Inject(_cameraFollower);
            // DependencyInjector.Inject(_moveController);
            
            // var playerService = ServiceLocator.GetService<IPlayerService>();
            // var keyboardInput = ServiceLocator.GetService<KeyboardInput>();
            //
            // _cameraFollower.Construct(playerService);
            // _moveController.Construct(keyboardInput, playerService); 
        }

        private void ResolveDependencies(Transform node)
        {
            var behaviours = node.GetComponents<MonoBehaviour>();

            foreach (var behaviour in behaviours)
            {
                DependencyInjector.Inject(behaviour);
            }

            foreach (Transform child in node)
            {
                ResolveDependencies(child);
            }
        }
    }
}