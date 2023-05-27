using System;
using System.Reflection;

namespace Lesson5DI2
{
    public static class DependencyInjector
    {
        public static void Inject(object target)
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

        private static void InvokeMethod(MethodInfo method, object target)
        {
            ParameterInfo[] parameters = method.GetParameters();

            object[] args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];
                Type type = parameter.ParameterType;
                object arg = ServiceLocator.GetService(type);
                args[i] = arg;
            }

            method.Invoke(target, args);
        }
    }
}