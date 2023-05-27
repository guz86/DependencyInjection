using UnityEngine;

namespace Lesson5DI
{
    public class MoveController : MonoBehaviour,
        // IGameInitListener,
        IGameStartListener,
        IGameFinishListener
    {
        private KeyboardInput _keyboardInput;
        private IPlayerService _playerService;

        //[Inject]
        public void Construct(KeyboardInput keyboardInput, IPlayerService playerService)
        {
            _keyboardInput = keyboardInput;
            _playerService = playerService;
        }

        // void IGameInitListener.OnInit()
        // {
        //     _keyboardInput = ServiceLocator.GetService<KeyboardInput>();
        //     _playerService = ServiceLocator.GetService<IPlayerService>();
        // }

        void IGameStartListener.OnStartGame()
        {
            _keyboardInput.OnMove += this.OnMove;
        }

        void IGameFinishListener.OnFinishGame()
        {
            _keyboardInput.OnMove -= this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            _playerService.GetPlayer().Move(offset);
        }
    }
}