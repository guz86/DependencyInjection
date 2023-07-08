using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.App
{
    public sealed class SaveRepository
    {
        public void SaveValue(string key, float value)
        {
            Debug.Log($"{key}: {value} was saved!");
        }
    }
}