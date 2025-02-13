using UnityEngine;

public class MenagerButtonsDown : MonoBehaviour
{
    [SerializeField] private protected GameObject [] activatedObgects;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float distanceToDrop = 20f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private bool invok = false;
    [SerializeField] private bool moveOnX = false;
    [SerializeField] private bool moveOnY = false;
    [SerializeField] private bool moveOnZ = false;

    private Vector3 startPosition;    // Начальная позиция объекта
    private protected int count = 0;

    private void Start()
    {
        startPosition = objectToMove.position;
    }

    private void Update()
    {
        AllTrue();
    }

    public virtual void  AllTrue()
    {
        count = 0;
        for (int i = 0; i < activatedObgects.Length; i++)
        {
            if (activatedObgects[i].GetComponent<TriggerBottonDown>().GetBoolBoxDown())
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
        if (count == activatedObgects.Length)
        {
            if (moveOnX)
                MoveObjectOnX();
            else if (moveOnY)
                MoveObjectOnY();
            else if (moveOnZ)
                MoveObjectOnZ();
        } else
        {
            ResetObjectPosition();
        }
    }
    private void MoveObjectOnX()
    {
        float targetX = startPosition.x + distanceToDrop * (invok ? 1 : -1);

        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            new Vector3(targetX, startPosition.y, startPosition.z),
            speed * Time.fixedDeltaTime);
    }

    private void MoveObjectOnZ()
    {
        float targetZ = startPosition.z + distanceToDrop * (invok ? 1 : -1);

        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            new Vector3(startPosition.x, startPosition.y, targetZ),
            speed * Time.deltaTime);
    }
    private void MoveObjectOnY()
    {
        float targetY = startPosition.y + distanceToDrop * (invok ? 1 : -1);

        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            new Vector3(startPosition.x, targetY, startPosition.z),
            speed * Time.deltaTime);
    }

    private void ResetObjectPosition()
    {
        objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y, startPosition.z),
                speed * Time.fixedDeltaTime);
    }
}