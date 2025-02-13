using UnityEngine;

public class TriggerBottonDown : MonoBehaviour
{
    private bool isDropping = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BoxActive") || other.CompareTag("Player"))
        {
            isDropping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDropping = false;
        }
    }
    public bool GetBoolBoxDown()
    {
        return isDropping;
    }
}
