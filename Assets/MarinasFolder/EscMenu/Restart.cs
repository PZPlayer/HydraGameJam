using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    
    void Update()
    {
        restartButton.onClick.AddListener(Newstart);
    }

    private void Newstart()
    {
        //������������ ������� �����        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
