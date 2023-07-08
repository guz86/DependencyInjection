﻿using Lesson6TeacherZenject.Scripts.Architecture;
using Lesson6TeacherZenject.Scripts.Game;
using Lesson6TeacherZenject.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    public sealed class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        //[SerializeField] private GameManager _gameManager;
        
        
        public override void InstallBindings()
        {
            
            Container.Bind<GameTimer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameOverScreen>().FromComponentInHierarchy().AsSingle();
            
            //Container.Bind<GameManagerContext>().AsSingle();
            
            //Container.Bind<IGameManager>().To<GameManager>().FromInstance(_gameManager).AsSingle();
            //Container.Bind<IGameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<IGameManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}