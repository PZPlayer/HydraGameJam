using UnityEngine;

public class TriggerBottonDown : MonoBehaviour
{
    private bool isDropping = false;
    [SerializeField] private bool canPlayer = true;
    [SerializeField] private float scale = 1;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BoxActive"))
        {
            // �������� Collider �������
            Collider boxCollider = other.GetComponent<Collider>();
            if (boxCollider != null)
            {
                Vector3 boxSize = boxCollider.bounds.size;
                if (boxSize.x == scale) // �������� 1.0 �� ���������� �������� ��� ������ ������
                {
                    isDropping = true;
                }
            }
        }
        if (other.CompareTag("Player") && canPlayer)
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
