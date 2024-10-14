using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleManager : MonoBehaviour {
    public GameObject[] puzzlePieces; // ������ ���� ������
    public Transform[] targetPositions; // ������ ������� ������� ��� ������
    //private bool test = false;
    private void OnEnable()
    {
        // ����� ��� ������� ������� � ����� "TargetPosition"
        targetPositions = GameObject.FindGameObjectsWithTag("TargetPosition")
                                    .Select(obj => obj.transform)
                                    .ToArray();
        HashSet<Vector3> uniquePositions = new HashSet<Vector3>();
        foreach (var position in targetPositions)
        {
            if (!uniquePositions.Add(position.position))
            {
                Debug.LogError("�������� ������� ������: " + position.position);
            }
        }

    }
    void Start()
    {

        // ���������, ��� ���������� ������� ������� ������������� ���������� ������
        if (puzzlePieces.Length > targetPositions.Length)
        {
            Debug.LogError("������������ ������� ������� ��� ���� ������!" + targetPositions.Length);
            return; // ��������� ����������, ���� �� ������� �������
        }

        // ���������� �������
        Shuffle(targetPositions);

        // ���������� ������ ���� �� ���� �� ������������ �������
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            // ������������� ��������� ������� ������� ����� ������������ ������������� �������
            puzzlePieces[i].transform.localPosition = targetPositions[i].localPosition;

            // ������������� �������� ������������ ������ ����
            int[] rotate = { 0, 90, 180, 270 };
            puzzlePieces[i].transform.Rotate(0, 0, rotate[Random.Range(0, rotate.Length)]);

            // ��� ��� ��������
            Debug.Log($"���� {puzzlePieces[i].name} ���������� �� ��������� ������� {puzzlePieces[i].transform.localPosition}, ����: {targetPositions[i].localPosition}");
        }
    }

    // ����� ��� ������������� �������
    void Shuffle(Transform[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}