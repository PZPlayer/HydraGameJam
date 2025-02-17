using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace Hydra.UI
{
    public class SettingsSaveConf : MonoBehaviour
    {
        [SerializeField] private Slider _mainVolume;
        [SerializeField] private TMP_Dropdown _languageSelect;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _saveButton1;
        [SerializeField] private Button _saveButton2;

        private void Awake()
        {
            Settings setngs = Settings.Setting;
            _mainVolume.value = setngs.MainVolume;
            _languageSelect.value = (int)(setngs.Language);
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
