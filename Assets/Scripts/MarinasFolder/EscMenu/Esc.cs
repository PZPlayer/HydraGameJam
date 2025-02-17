using Hydra.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Esc : MonoBehaviour
{
    public GameObject panel;
    public Button playButton;
    public Slider VolumeSlider;

    private bool isPanelOpen = false; 
    
    void Start()
    {
        panel.SetActive(false);

        playButton.onClick.AddListener(TogglePanel);
        if(Settings.Setting != null)
        {
            VolumeSlider.value = Settings.Setting.MainVolume;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePanel();
        }
    }

    public void ChangeVolumeValue(Slider slider)
    {
        Settings.Setting.MainVolume = slider.value;
    }

    void TogglePanel()
    {
        isPanelOpen = !isPanelOpen; // Переключаем состояние панели
        panel.SetActive(isPanelOpen); // Показываем или скрываем панель        
    }

    public void LoadSomeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
