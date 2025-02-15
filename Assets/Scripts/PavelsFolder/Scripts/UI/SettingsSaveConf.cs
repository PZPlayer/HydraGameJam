using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Hydra.UI
{
    public class SettingsSaveConf : MonoBehaviour
    {
        [SerializeField] private Slider _mainVolume;
        [SerializeField] private TMP_Dropdown _languageSelect;

        private void Awake()
        {
            Settings setngs = Settings.Setting;
            _mainVolume.value = setngs.MainVolume;
            _languageSelect.value = (int)(setngs.Language);
        }
    }

}
