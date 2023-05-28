using System;
using System.Reflection;

namespace Lesson5DI3
{
    internal sealed class GameInjector
    {
        private readonly GameLocator _serviceLocator;

        public GameInjector(GameLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        internal void Inject(object target)
        {
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.FlattenHierarchy
            );

            foreach (var method in methods)
            {
                if (method.IsDefined(typeof(InjectAttribute)))
                {
                    InvokeMethod(method, target);
                }
            }
        }

        private void InvokeMethod(MethodInfo method, object target)
        {
            ParameterInfo[] parameters = method.GetParameters();

            object[] args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];
                Type type = parameter.ParameterType;
                object arg = _serviceLocator.GetService(type);
                args[i] = arg;
            }

            method.Invoke(target, args);
        }
    }
}