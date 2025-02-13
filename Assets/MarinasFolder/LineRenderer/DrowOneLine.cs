using UnityEngine;

public class DrowOneLine : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;

        SetLinePoints(point1.position, point2.position);
    }

    void SetLinePoints(Vector3 startPosition, Vector3 endPosition)
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

    void Update()
    {
        // Обновляем позицию линии, если позиции точек изменились
        SetLinePoints(point1.position, point2.position);
    }
}
