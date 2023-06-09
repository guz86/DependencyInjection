﻿using System;
using Lesson5ServiceLocator.Scripts.GameSystem;
using UnityEngine;

namespace Lesson5ServiceLocator.Scripts.Systems
{
    public class KeyboardInput : MonoBehaviour,
        IGameUpdateListener
    {
        public event Action<Vector2> OnMove;

        void IGameUpdateListener.OnUpdate(float deltaTime)
        {
            HandleKeyboard();
        }

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
    }
}