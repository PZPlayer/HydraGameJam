using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MenagerButtonsDown : MonoBehaviour
{
    [SerializeField] private GameObject [] downBox;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float distanceToDrop = 20f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private bool invok = false;

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
            MoveObjectMove();
        } else
        {
            MoveObjectAgaing();
        }
    }

    private void MoveObjectMove()
    {
        float targetY = startPosition.y + distanceToDrop * (invok ? 1 : -1);

        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            new Vector3(startPosition.x, targetY, startPosition.z),
            speed * Time.deltaTime);
    }

    private void MoveObjectAgaing()
    {
        objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y, startPosition.z),
                speed * Time.fixedDeltaTime);
    }
}