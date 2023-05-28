using System.Collections.Generic;
using UnityEngine;

namespace Lesson5DI3
{
    public sealed class PlayerModule : GameModule
    {
        [SerializeField] private CameraFollower _cameraFollower = new CameraFollower();
        [SerializeField] private PlayerService _playerService = new PlayerService();

        private readonly MoveController _moveController = new MoveController();
        private readonly KeyboardInput _keyboardInput = new KeyboardInput();

        public override IEnumerable<object> GetServices()
        {
            yield return _playerService;
            yield return _keyboardInput;
        }

        public override IEnumerable<IGameListener> GetListeners()
        {
            yield return _cameraFollower;
            yield return _moveController;
            yield return _keyboardInput;
        }

        public override void ResolveDependencies(GameSystem gameSystem)
        {
            _cameraFollower.Construct(_playerService);
            _moveController.Construct(_keyboardInput, _playerService);
        }
    }
}