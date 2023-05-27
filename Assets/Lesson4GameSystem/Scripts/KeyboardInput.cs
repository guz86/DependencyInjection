using System;
using Lesson4GameSystem.Scripts.GameSystem;
using UnityEngine;

namespace Lesson4GameSystem.Scripts
{
    public class KeyboardInput : MonoBehaviour,
        // IGameStartListener,
        // IGameFinishListener,
        IGameUpdateListener
    {
        public event Action<Vector2> OnMove;

        // private void Awake()
        // {
        //     enabled = false;
        // }

        void IGameUpdateListener.OnUpdate(float deltaTime)
        {
            HandleKeyboard();
        }

        // private void Update()
        // {
        //     HandleKeyboard();
        // }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.Move(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.Move(Vector2.down);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.Move(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.Move(Vector2.right);
            }
        }

        private void Move(Vector2 direction)
        {
            this.OnMove?.Invoke(direction);
        }

        // void IGameStartListener.OnStartGame()
        // {
        //     enabled = true;
        // }
        //
        // void IGameFinishListener.OnFinishGame()
        // {
        //     enabled = false;
        // }
    }
}