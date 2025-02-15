using UnityEngine;
using TMPro;

namespace Hydra.UI
{
    public class TextTranslate : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _writebleText;
        [SerializeField] private string _textInEnglish;
        [SerializeField] private string _textInRussian;
        private Languages curLanguage;

        void Start()
        {
            if (_writebleText == null)
            {
                _writebleText = GetComponent<TextMeshProUGUI>();
            }
            UpdateText();
        }

        public void UpdateText()
        {
            curLanguage = Settings.Setting.Language;
            _writebleText.text = curLanguage == Languages.Eng ? _textInEnglish : _textInRussian;
        }
    }

}
