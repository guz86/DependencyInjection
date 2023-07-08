using UnityEngine.SceneManagement;

namespace Lesson6TeacherZenject.Scripts.App
{
    public static class SceneController
    {
        public static void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}