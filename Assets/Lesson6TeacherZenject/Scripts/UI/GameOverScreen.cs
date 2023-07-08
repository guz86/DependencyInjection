using Lesson6TeacherZenject.Scripts.App;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lesson6TeacherZenject.Scripts.UI
{
    [AddComponentMenu("Lesson6/GameOverScreen")]
    public sealed class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(SceneController.RestartCurrentScene);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(SceneController.RestartCurrentScene);
        }

        public void Show(string text)
        {
            gameObject.SetActive(true);

            _text.text = text;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}