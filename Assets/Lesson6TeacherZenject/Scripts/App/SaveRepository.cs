using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.App
{
    public static class SaveRepository
    {
        public static void SaveValue(string key, float value)
        {
            Debug.Log($"{key}: {value} was saved!");
        }
    }
}