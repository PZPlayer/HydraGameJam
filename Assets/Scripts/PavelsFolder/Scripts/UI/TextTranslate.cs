using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Hydra.UI
{
    public class TextTranslate : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _writebleText;
        [SerializeField] private string _textInEnglish;
        [SerializeField] private string _textInRussian;
        private Languages curLanguage;
        private Text text;

        void Start()
        {
            if (_writebleText == null)
            {
                _writebleText = GetComponent<TextMeshProUGUI>();
                if(_writebleText == null)
                {
                    text = GetComponent<Text>();
                }
            }
            if (Settings.Setting != null)
            {
                UpdateText();
            }
            else
            {
                print(Settings.Setting + " 404");
            }
            
        }

        public void UpdateText()
        {
            curLanguage = Settings.Setting.Language;
            if(_writebleText == null)
            {
                text.text = curLanguage == Languages.Eng ? _textInEnglish : _textInRussian;
                return;
            }
            _writebleText.text = curLanguage == Languages.Eng ? _textInEnglish : _textInRussian;
        }
    }

}
