using System.Collections;
using UnityEngine;

public class TriggerZoneDown : MonoBehaviour
{
    [SerializeField] private Transform objectToMove;   // Объект, который будем опускать
    [SerializeField] private float distanceToDrop = 20f; // Расстояние, на которое опустим объект
    [SerializeField] private float speed = 0.5f;       // Скорость движения (значение меньше для медленного движения)

    private Vector3 startPosition;    // Начальная позиция объекта
    private bool isDropping = false;  // Флаг, определяющий начало опускания

    private void Start()
    {
        startPosition = objectToMove.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDropping)
        {
            isDropping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDropping)
        {
            MoveObjectDown();
        }
    }

    private void MoveObjectDown()
    {
        if (objectToMove.position.y > startPosition.y - distanceToDrop)
        {
            // Перемещаем объект вниз
            objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y - distanceToDrop, startPosition.z),
                speed * Time.fixedDeltaTime);
        }
        else
        {
            // Завершаем движение
            objectToMove.position = new Vector3(startPosition.x, startPosition.y - distanceToDrop, startPosition.z);
            isDropping = false;
        }
    }
}
