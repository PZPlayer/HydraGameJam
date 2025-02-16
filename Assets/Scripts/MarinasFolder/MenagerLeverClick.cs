using UnityEditor;
using UnityEngine;

public class MenagerLeverClick : MonoBehaviour
{

    [SerializeField] private protected GameObject[] activatedObgects;

    [SerializeField] private GameObject[] createObjects;
    private int countDoun = 0;
    private bool doneOnce = false;

    private void Update()
    {
        if(doneOnce) return;
        AllTrue();
        if (countDoun == activatedObgects.Length)
        {
            SetActiveGameObject();
        }
    }
    private void AllTrue()
    {
        countDoun = 0;
        for (int i = 0; i < activatedObgects.Length; i++)
        {
            if (activatedObgects[i].GetComponent<TriggerLever>().GetBoolLever())
            {
                countDoun++;
            }
            else
            {
                countDoun--;
            }
        }
    }

    private void SetActiveGameObject()
    {
            for (int i = 0; i < createObjects.Length; i++)
            {
                createObjects[i].SetActive(true);
            }
            doneOnce = true;
    }
}
