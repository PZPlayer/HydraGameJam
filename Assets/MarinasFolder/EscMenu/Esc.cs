using UnityEngine;
using UnityEngine.UI;

public class Esc : MonoBehaviour
{
    public GameObject panel;
    public Button playButton;

    private bool isPanelOpen = false; 
    
    void Start()
    {
        panel.SetActive(false);

        playButton.onClick.AddListener(TogglePanel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }

    void TogglePanel()
    {
        isPanelOpen = !isPanelOpen; // Переключаем состояние панели
        panel.SetActive(isPanelOpen); // Показываем или скрываем панель        
    }
}
