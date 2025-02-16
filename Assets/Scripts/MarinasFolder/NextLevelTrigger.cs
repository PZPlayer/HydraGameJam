using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private ClickToLoadScene clickToLoadScene;
    private void Awake()
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
