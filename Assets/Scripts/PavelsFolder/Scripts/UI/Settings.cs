using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


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
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (Setting != null && Setting != this)
            {
                Destroy(gameObject);
                return;
            }
            Setting = this;
            DontDestroyOnLoad(gameObject);
        }

        void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            AudioSource[] audioSources = FindObjectsOfType<AudioSource>(); 

            if(audioSources.Length > 0 )
            {
                for(int i = 0; i < audioSources.Length; i++)
                {
                    AudioSource source = audioSources[i];
                    source.volume *= MainVolume;
                }
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

        public void LoadScene()
        {
            SceneManager.LoadScene(DeathManager.Instance.SceneLastDeath);
        }

        public void LoadSomeScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void LaveGame()
        {
            Application.Quit();
        }
    }
}



