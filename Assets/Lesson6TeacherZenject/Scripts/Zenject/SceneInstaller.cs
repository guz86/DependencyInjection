using Lesson6TeacherZenject.Scripts.Architecture;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    public sealed class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        //[SerializeField] private GameManager _gameManager;
        
        
        public override void InstallBindings()
        {
            //Container.Bind<GameManagerContext>().AsSingle();
            
            //Container.Bind<IGameManager>().To<GameManager>().FromInstance(_gameManager).AsSingle();
            //Container.Bind<IGameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<IGameManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}