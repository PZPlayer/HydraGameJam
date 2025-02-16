using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    private ClickToLoadScene clickToLoadScene;
    private void Start()
    {
        clickToLoadScene = FindObjectOfType<ClickToLoadScene>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clickToLoadScene.NextLevel();
        }
    }
}
