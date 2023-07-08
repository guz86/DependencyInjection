using TMPro;
using UnityEngine;

namespace Lesson6TeacherZenject.Scripts.UI
{
    [AddComponentMenu("Lesson6/TextWidget")]
    public sealed class TextWidget : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}