using System.Collections.Generic;
using UnityEngine;

namespace Lesson5DI3
{
    public abstract class GameModule : MonoBehaviour
    {
        public abstract IEnumerable<object> GetServices();
        
        public abstract IEnumerable<IGameListener> GetListeners();

        public abstract void ResolveDependencies(GameSystem gameSystem);
        
    }
}