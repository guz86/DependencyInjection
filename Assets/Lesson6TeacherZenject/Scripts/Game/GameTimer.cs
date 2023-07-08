using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Game
{
    [DefaultExecutionOrder(-100)]
    [AddComponentMenu("Lesson6/GameTimer")]
    public sealed class GameTimer : ITickable
    {
  //      public static GameTimer Instance { get; private set; }

        public event Action<float> Ticked;

        [ShowInInspector, ReadOnly]
        public float Time { get; private set; }
        
        [ShowInInspector, ReadOnly]
        public bool IsSet { get; private set; }

        // private void Awake()
        // {
        //     if (Instance != null)
        //     {
        //         Destroy(this);
        //     }
        //     else
        //     {
        //         Instance = this;
        //     }
        // }

        void ITickable.Tick()
        {
            if (IsSet)
            {
                Time += UnityEngine.Time.deltaTime;
                Ticked?.Invoke(Time);
            }
        }

        public void Start()
        {
            Time = 0f;
            IsSet = true;
        }

        public void Stop()
        {
            IsSet = false;
        }
    }
}