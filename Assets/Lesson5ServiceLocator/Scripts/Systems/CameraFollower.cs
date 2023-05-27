using Lesson5ServiceLocator.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5ServiceLocator.Scripts.Systems
{
    public class CameraFollower : MonoBehaviour, IGameLateUpdateListener
    {
        [SerializeField] private Camera targetCamera;

        [SerializeField] private Vector3 offset;


        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            this.targetCamera.transform.position = ServiceLocator.GetService<PlayerService>()
                .GetPlayer()
                .GetPosition() + this.offset;
        }
    }
}