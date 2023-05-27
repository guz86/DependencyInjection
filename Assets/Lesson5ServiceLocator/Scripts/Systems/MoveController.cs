using Lesson5ServiceLocator.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5ServiceLocator.Scripts.Systems
{
    public class MoveController : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        //[SerializeField] private Player _player;
        //[SerializeField] private PlayerService _playerService;
        //[SerializeField] private KeyboardInput input;
        
        

        void IGameStartListener.OnStartGame()
        {
            //this.input.OnMove += this.OnMove;
            //KeyboardInput.Instance.OnMove += this.OnMove;
            ServiceLocator.GetService<KeyboardInput>().OnMove += this.OnMove;
        }

        void IGameFinishListener.OnFinishGame()
        {
            //this.input.OnMove -= this.OnMove;
            //KeyboardInput.Instance.OnMove -= this.OnMove;
            ServiceLocator.GetService<KeyboardInput>().OnMove += this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            //_player.Move(offset);
            //_playerService.GetPlayer().Move(offset);
            //PlayerService.Instance.GetPlayer().Move(offset);
            ServiceLocator.GetService<PlayerService>().GetPlayer().Move(offset);
        }
    }
}