using Lesson6TeacherZenject.Scripts.App;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    public sealed class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SaveRepository>().AsSingle();
            Container.Bind<SceneController>().AsSingle();
        }
    }
}