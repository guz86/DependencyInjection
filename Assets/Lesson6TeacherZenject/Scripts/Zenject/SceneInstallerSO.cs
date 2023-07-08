using Lesson6TeacherZenject.Scripts.Game;
using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    [CreateAssetMenu(fileName = "SceneInstaller", menuName = "Lesson6/SceneInstaller")]
    public class SceneInstallerSO : ScriptableObjectInstaller<SceneInstallerSO>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameTimerController>().AsSingle();
            Container.BindInterfacesTo<GameOverScreenController>().AsSingle();
        }
    }
}