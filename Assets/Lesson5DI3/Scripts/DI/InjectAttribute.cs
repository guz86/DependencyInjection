using System;
using JetBrains.Annotations;

namespace Lesson5DI3
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute
    {
        
    }
}