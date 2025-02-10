using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Hydra.UI
{
    public enum Languages
    {
        Eng = 0,
        Rus = 1
    }


    public class Settings : MonoBehaviour
    {
        public static Settings Setting;

        public Languages Language;
        public float MainVolume;

        void Start()
        {
            if (Setting == null)
            {
                Setting = this;
            }
        }

        public void ChangeMainVolume(Slider slider)
        {
            MainVolume = slider.value;
        }

        public void ChangeLanguage(TMP_Dropdown slider)
        {
            Language = (Languages)slider.value;

            TextTranslate[] translates = FindObjectsOfType<TextTranslate>();
            foreach (TextTranslate t in translates)
            {
                t.UpdateText();
            }
        }
    }
}



