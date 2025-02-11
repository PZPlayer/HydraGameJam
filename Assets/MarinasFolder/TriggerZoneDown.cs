using System.Collections;
using UnityEngine;

public class TriggerZoneDown : MonoBehaviour
{
    [SerializeField] private Transform objectToMove;   // ������, ������� ����� ��������
    [SerializeField] private float distanceToDrop = 20f; // ����������, �� ������� ������� ������
    [SerializeField] private float speed = 0.5f;       // �������� �������� (�������� ������ ��� ���������� ��������)

    private Vector3 startPosition;    // ��������� ������� �������
    private bool isDropping = false;  // ����, ������������ ������ ���������

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
            // ���������� ������ ����
            objectToMove.position = Vector3.MoveTowards(
                objectToMove.position,
                new Vector3(startPosition.x, startPosition.y - distanceToDrop, startPosition.z),
                speed * Time.fixedDeltaTime);
        }
        else
        {
            // ��������� ��������
            objectToMove.position = new Vector3(startPosition.x, startPosition.y - distanceToDrop, startPosition.z);
            isDropping = false;
        }
    }
}
