using UnityEditor;
using UnityEngine;

public class MenagerLeverClick : MonoBehaviour
{

    [SerializeField] private protected GameObject[] activatedObgects;

    [SerializeField] private GameObject[] createObjects;
    [SerializeField] private GameObject [] createPointObjects;
    private int countDoun = 0;
    private bool doneOnce = false;

    private void Update()
    {
        if(doneOnce) return;
        AllTrue();
        if (countDoun == activatedObgects.Length)
        {
            CreateGameObject();
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

    private void CreateGameObject()
    {
            for (int i = 0; i < createObjects.Length; i++)
            {
                Instantiate(createObjects[i], createPointObjects[i].transform.position, createPointObjects[i].transform.rotation);
                createObjects[i].SetActive(true);
            }
            doneOnce = true;
    }
}
