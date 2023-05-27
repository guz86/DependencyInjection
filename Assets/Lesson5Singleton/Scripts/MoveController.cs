﻿using Lesson4GameSystem.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5Singleton.Scripts
{
    public class MoveController : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        [SerializeField] private Player player;

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
            this.player.Move(offset);
        }
    }
}