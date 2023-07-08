using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    [AddComponentMenu("Lesson6/GameListenerInstaller")]
    public sealed class GameListenerInstaller : MonoInstaller<GameListenerInstaller>
    {
        //[Inject]
        //private readonly IGameManager _gameManager;
        
        // private void Awake()
        // {
        //     //var gameManager = GameManager.Instance;
        //     
        //     foreach (var gameListener in GetComponentsInChildren<IGameListener>())
        //     {
        //         _gameManager.AddListener(gameListener);
        //     }
        // }

        public override void InstallBindings()
        {
            foreach (var gameListener in GetComponentsInChildren<IGameListener>())
            {
                Container.Bind<IGameListener>().FromInstance(gameListener).AsCached();
            }
        }
    }
} 