using Lesson4GameSystem.Scripts;
using UnityEngine;

namespace Lesson4.Scripts
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        [SerializeField]
        private KeyboardInput input;
        
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