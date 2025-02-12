using UnityEngine;

public class MenagerButtonsDown : MonoBehaviour
{
    [SerializeField] private GameObject [] downBox;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float distanceToDrop = 20f;
    [SerializeField] private float speed = 0.5f;

    private Vector3 startPosition;    // Начальная позиция объекта
    private int count = 0;

    private void Start()
    {
        startPosition = objectToMove.position;
    }

    private void Update()
    {
        count = 0;
        for (int i = 0; i < downBox.Length; i++)
        {
            if (downBox[i].GetComponent<TriggerBottonDown>().GetBoolBoxDown())
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
        
        if (count == downBox.Length)
        {
            MoveObjectDown();
        } else
        {
            MoveObjectUp();
        }
    }

    private void MoveObjectDown()
    {
        if (objectToMove.position.y > startPosition.y - distanceToDrop)
        {
            objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y - distanceToDrop, startPosition.z),
                speed * Time.fixedDeltaTime);
        }
    }

    private void MoveObjectUp()
    {
        if (objectToMove.position.y < startPosition.y)
        {
            objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y, startPosition.z),
                speed * Time.fixedDeltaTime);
        }
    }
}