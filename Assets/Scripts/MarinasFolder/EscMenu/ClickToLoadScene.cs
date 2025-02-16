using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoadScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject notLoad;

    public void OnButtonClickToLoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void NextLevel()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        print(totalScenes);
        if (SceneManager.GetActiveScene().buildIndex < totalScenes - 1)
        {
            print(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}