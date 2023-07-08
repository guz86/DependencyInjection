using UnityEngine;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterController>().FromComponentInHierarchy().AsSingle();
        }
    }
}