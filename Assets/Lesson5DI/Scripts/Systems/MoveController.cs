using Lesson5DI.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5DI.Scripts.Systems
{
    public class MoveController : MonoBehaviour,
        IGameInitListener,
        IGameStartListener,
        IGameFinishListener
    {
        private KeyboardInput _keyboardInput;
        private IPlayerService _playerService;

        void IGameInitListener.OnInit()
        {
            _keyboardInput = ServiceLocator.GetService<KeyboardInput>();
            _playerService = ServiceLocator.GetService<IPlayerService>();
        }

        void IGameStartListener.OnStartGame()
        {
            //ServiceLocator.GetService<KeyboardInput>().OnMove += this.OnMove;
            _keyboardInput.OnMove += this.OnMove;
        }

        void IGameFinishListener.OnFinishGame()
        {
            //ServiceLocator.GetService<KeyboardInput>().OnMove -= this.OnMove;
            _keyboardInput.OnMove -= this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            //ServiceLocator.GetService<PlayerService>().GetPlayer().Move(offset);
            _playerService.GetPlayer().Move(offset);
        }
    }
}