using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoIntersections : MonoBehaviour
{

    [SerializeField] private AudioClip correctAudioClip;
    [SerializeField] private AudioClip incorrectAudioClip;
    [SerializeField] private Button chek;
    [SerializeField] private List<LineRenderer> lines;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lines = new List<LineRenderer>(FindObjectsOfType<LineRenderer>());
        chek.onClick.AddListener(ChekPoints);
    }

    private void ChekPoints()
    {
        lines = new List<LineRenderer>(FindObjectsOfType<LineRenderer>());

        if (!AreLinesIntersecting(lines))
        {
            // ������ ��� ��������� ���������� ������
            Debug.Log("������� �������!");
            audioSource.PlayOneShot(correctAudioClip);
            // ����� ����� �������� �������������� ������, ��������, ������� �� ��������� �������
        }
        else
        {
            audioSource.PlayOneShot(incorrectAudioClip);
            Debug.Log("����� ������������, ���������� ��� ���.");
        }
    }

    private bool AreLinesIntersecting(List<LineRenderer> linesRenderer)
    {
        for (int i = 0; i < linesRenderer.Count; i++)
        {
            LineRenderer currentLine = linesRenderer[i];
            Vector3[] currentPoints = new Vector3[currentLine.positionCount];
            currentLine.GetPositions(currentPoints);

            for (int j = i + 1; j < linesRenderer.Count; j++)
            {
                LineRenderer otherLine = linesRenderer[j];
                Vector3[] otherPoints = new Vector3[otherLine.positionCount];
                otherLine.GetPositions(otherPoints);

                for (int k = 0; k < currentPoints.Length - 1; k++)
                {
                    for (int l = 0; l < otherPoints.Length - 1; l++)
                    {
                        if (DoSegmentsIntersect(
                            currentPoints[k], currentPoints[k + 1],
                            otherPoints[l], otherPoints[l + 1]
                        ))
                        {
                            return true; // ����������� �������
                        }
                    }
                }
            }
        }

        return false; // ����������� �� �������
    }

    private static bool DoSegmentsIntersect(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
    {
        float denominator = (end2.z - start2.z) * (end1.x - start1.x) - (end2.x - start2.x) * (end1.z - start1.z);

        if (denominator == 0)
        {
            return false; // ������������ �����
        }

        float ua = ((end2.x - start2.x) * (start1.z - start2.z) - (end2.z - start2.z) * (start1.x - start2.x)) / denominator;
        float ub = ((end1.x - start1.x) * (start1.z - start2.z) - (end1.z - start1.z) * (start1.x - start2.x)) / denominator;
        // �������� �� �����������, �������� ����� �������� � ������/����� ������� �������
        if (ua > 0 && ua < 1 && ub > 0 && ub < 1)
        {
            if (ua != ub)         
                return true; // �����������
        }

        return false; // ��� �����������
    }
}