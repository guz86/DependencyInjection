using UnityEngine;

namespace Lesson6Zenject.Scripts
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        [SerializeField]
        private Lesson4Start.KeyboardInput input;
        
        void OnEnable()
        {
            this.input.OnMove += this.OnMove;
        }

        void OnDisable()
        {
            this.input.OnMove -= this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            this.player.Move(offset);
        }
    }
}