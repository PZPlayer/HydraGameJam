using UnityEngine;

public class MenagerLeverClick : MonoBehaviour
{
    [SerializeField] private GameObject[] lever;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float distanceToDrop = 20f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private bool invok = false;
    [SerializeField] private bool osX = false;
    [SerializeField] private bool osZ = false;

    private Vector3 startPosition;    // Начальная позиция объекта
    private int count = 0;

    private void Start()
    {
        startPosition = objectToMove.position;
    }

    private void Update()
    {
        count = 0;
        for (int i = 0; i < lever.Length; i++)
        {
            if (lever[i].GetComponent<TriggerLever>().GetBoolLever())
            {
                count++;
            }
            else
            {
                count--;
            }
        }
    }

    private void FixedUpdate()
    {

        if (count == lever.Length)
        {
            if (osX)
                if (startPosition == objectToMove.transform.position)
                {
                    if (invok)
                        MoveObjectLeftX();
                    else MoveObjectiRightX();
                }
                else
                {
                    if (invok)
                        MoveObjectiRightX();
                    else MoveObjectLeftX();
                }
            
                
           
        }
        else
        {
            if (osX)
                if (invok)
                    MoveObjectiRightX();
                else MoveObjectLeftX();
        }
    }

    private void MoveObjectLeftX()
    {
        if (objectToMove.position.x > startPosition.x - distanceToDrop)
        {
            objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x - distanceToDrop, startPosition.y, startPosition.z),
                speed * Time.fixedDeltaTime);
        }
    }

    private void MoveObjectiRightX()
    {
        if (objectToMove.position.z < startPosition.z)
        {
            objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y, startPosition.z),
                speed * Time.fixedDeltaTime);
        }
    }
}
