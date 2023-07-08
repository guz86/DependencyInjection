using Lesson6TeacherZenject.Scripts.Architecture;
using Lesson6TeacherZenject.Scripts.Game;
using Lesson6TeacherZenject.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    public sealed class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        //[SerializeField] private GameManager _gameManager;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileParentTransform;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Projectile, Projectile.Pool>().WithInitialSize(5)
                .FromComponentInNewPrefab(_projectilePrefab).UnderTransform(_projectileParentTransform).AsSingle();

            Container.Bind<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle();


            //Container.Bind<Player>().FromComponentInHierarchy().AsSingle();

            //Container.Bind<GameTimer>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimer>().AsSingle();

            Container.Bind<GameOverScreen>().FromComponentInHierarchy().AsSingle();

            //Container.Bind<GameManagerContext>().AsSingle();

            //Container.Bind<IGameManager>().To<GameManager>().FromInstance(_gameManager).AsSingle();
            //Container.Bind<IGameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<IGameManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}