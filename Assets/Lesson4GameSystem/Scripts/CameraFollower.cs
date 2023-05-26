using Lesson4GameSystem.Scripts.GameSystem;
using UnityEngine;

namespace Lesson4GameSystem.Scripts
{
    public class CameraFollower : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        [SerializeField]
        private Camera targetCamera;

        [SerializeField]
        private Player player;

        [SerializeField]
        private Vector3 offset;
        
        private void Awake()
        {
            enabled = false;
        }

        private void LateUpdate()
        {
            this.targetCamera.transform.position = this.player.GetPosition() + this.offset;
        }

        void IGameStartListener.OnStartGame()
        {
            enabled = true;
        }

        void IGameFinishListener.OnFinishGame()
        {
            enabled = false;
        }
    }
}