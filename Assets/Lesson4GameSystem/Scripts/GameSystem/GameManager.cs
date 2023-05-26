using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lesson4GameSystem.Scripts.GameSystem
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }

    public sealed class GameManager : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public GameState State
        {
            get { return this.state; }
        }

        private GameState state;
        
        private readonly List<IGameListener> listeners = new();
        
        public void AddListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }
            
            this.listeners.Add(listener);
        }


        [Button]
        public void StartGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            this.state = GameState.PLAYING;
        }

        [Button]
        public void PauseGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }

            this.state = GameState.PAUSED;
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }

            this.state = GameState.PLAYING;
        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }

            this.state = GameState.FINISHED;
        }
    }
}