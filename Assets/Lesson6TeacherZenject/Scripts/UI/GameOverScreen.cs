using Lesson6TeacherZenject.Scripts.App;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lesson6TeacherZenject.Scripts.UI
{
    [AddComponentMenu("Lesson6/GameOverScreen")]
    public sealed class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Button _restartButton;

        [SerializeField] private SceneController _sceneController;
        
        [Inject]
        public void Construct(SceneController sceneController)
        {
            _sceneController = sceneController;
        }
        
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(_sceneController.RestartCurrentScene);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(_sceneController.RestartCurrentScene);
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