using System.Collections.Generic;

namespace Lesson6TeacherZenject.Scripts.Architecture
{
    public sealed class GameManagerContext
    {
        //private readonly List<IGameListener> _listeners = new();
        private readonly List<IGameListener> _listeners;

        public GameManagerContext(IEnumerable<IGameListener> listeners)
        {
            _listeners = new List<IGameListener>(listeners);
        }
        

        public void AddListener(IGameListener listener)
        {
            _listeners.Add(listener);
        }
        
        public void OnGameInitialized()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IInitializeGameListener initializeListener)
                {
                    initializeListener.OnGameInitialized();
                }
            }
        }

        public void OnGameStarted()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startListener)
                {
                    startListener.OnGameStarted();
                }
            }
        }

        public void OnGameFinished()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IFinishGameListener finishListener)
                {
                    finishListener.OnGameFinished();
                }
            }
        }
    }
}