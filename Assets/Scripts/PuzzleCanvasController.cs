using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCanvasController : MonoBehaviour
{
    public GameObject popupPanel; // ��������� Panel
    public Transform player; // ��������� ������
    public Transform interactableObject; // ��������� ������, � ������� ���������������
    public float interactionDistance = 2f; // ���������� ��� ��������������

    void Start()
    {
        popupPanel.SetActive(false); // ������ ������ ��� �������
    }

    void Update()
    {
        // ��������� ���������� ����� ������� � ��������
        float distance = Vector2.Distance(player.position, interactableObject.position);

        if (distance < interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TogglePopup();
            }
        }
        else if (popupPanel.activeSelf)
        {
            // ���� ������ ������� � ����� ���������, �������� ������
            popupPanel.SetActive(false);
        }
    }

    void TogglePopup()
    {
        popupPanel.SetActive(!popupPanel.activeSelf);
    }
}
