using System;
using UnityEngine;

namespace Lesson5DI3
{
    [Serializable]
    public class CameraFollower :
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
            var position = _playerService.GetPlayer().GetPosition();
            this.targetCamera.transform.position = position + this.offset;
        }
    }
}