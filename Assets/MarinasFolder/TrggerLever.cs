using UnityEngine;

public class TriggerLever : MonoBehaviour
{
    private bool enter = false;
    private bool isActiv = false;
    [SerializeField] private KeyCode buttonName;

    private void Update()
    {
        if (enter && Input.GetKeyDown(buttonName))
        {
            isActiv = !isActiv;
            print("Тык");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
    public bool GetBoolLever()
    {
        return isActiv;
    }
}
