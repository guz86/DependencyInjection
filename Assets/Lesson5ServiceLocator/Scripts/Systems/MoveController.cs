using Lesson5ServiceLocator.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5ServiceLocator.Scripts.Systems
{
    public class MoveController : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        void IGameStartListener.OnStartGame()
        {
            ServiceLocator.GetService<KeyboardInput>().OnMove += this.OnMove;
        }

        void IGameFinishListener.OnFinishGame()
        {
            ServiceLocator.GetService<KeyboardInput>().OnMove += this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            ServiceLocator.GetService<PlayerService>().GetPlayer().Move(offset);
        }
    }
}