using Lesson5Singleton.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5Singleton.Scripts.Systems
{
    public class MoveController : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        //[SerializeField] private Player _player;
        [SerializeField] private PlayerService _playerService;

        [SerializeField] private KeyboardInput input;

        void IGameStartListener.OnStartGame()
        {
            this.input.OnMove += this.OnMove;
        }

        void IGameFinishListener.OnFinishGame()
        {
            this.input.OnMove -= this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            //_player.Move(offset);
            _playerService.GetPlayer().Move(offset);
        }
    }
}