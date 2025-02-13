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
        foreach (var l in lever)
        {
            if (l.GetComponent<TriggerLever>().GetBoolLever())
            {
                count++;
            }
        }        
    }

    private void FixedUpdate()
    {

        if (count == lever.Length)
        {

            if (osX)
                MoveObjectOsX();
            else if (osZ)
                MoveObjectOsZ();
        }
        else
        {
            ResetObjectPosition();
        }
    }

    private void MoveObjectOsX()
    {
        float targetX = startPosition.x + distanceToDrop * (invok ? 1 : -1);

        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            new Vector3(targetX, startPosition.y, startPosition.z),
            speed * Time.fixedDeltaTime);
    }  
    
    private void MoveObjectOsZ()
    {
        float targetZ = startPosition.z + distanceToDrop * (invok ? 1 : -1);

        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            new Vector3(startPosition.x, startPosition.y, targetZ),
            speed * Time.deltaTime);
    }
    private void ResetObjectPosition()
    {
        objectToMove.position = Vector3.MoveTowards(
            objectToMove.position,
            startPosition,
            speed * Time.fixedDeltaTime);
    }
}
