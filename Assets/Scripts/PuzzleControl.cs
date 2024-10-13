using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour {
    private static Puzzles selectedPuzzle; // ������� ��������� ����

    private void OnMouseOver()
    {
        // �������� ������� ������ ������ ����
        if (Input.GetMouseButtonDown(1))
        {
            // ������� ���� �� 90 ��������
            transform.Rotate(0, 0, 90);
        }

        // �������� ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedPuzzle == null)
            {
                // ���� ������ �� �������, �������� ������� ����
                selectedPuzzle = this;
            }
            else
            {
                // ���� ������ ������ ����, ������ �� �������
                SwapPositions(selectedPuzzle, this);
                selectedPuzzle = null; // ���������� ��������� ����
            }
        }
    }

    private void SwapPositions(Puzzles puzzle1, Puzzles puzzle2)
    {
        // ��������� ������� ������� ������� �����
        Vector3 tempPosition = puzzle1.transform.position;

        // ���������� ������ ���� �� ������� �������
        puzzle1.transform.position = puzzle2.transform.position;

        // ���������� ������ ���� �� ���������� ������� �������
        puzzle2.transform.position = tempPosition;
    }
}