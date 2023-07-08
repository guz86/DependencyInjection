using UnityEngine.SceneManagement;

namespace Lesson6TeacherZenject.Scripts.App
{
    public sealed class SceneController
    {
        public  void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}