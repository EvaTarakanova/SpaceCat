using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCanvasController : MonoBehaviour
{
    public GameObject popupPanel; // назначаем Panel
    public Transform player; // назначаем игрока
    public Transform interactableObject; // назначаем объект, с которым взаимодействуем
    public float interactionDistance = 2f; // расстояние для взаимодействия

    void Start()
    {
        popupPanel.SetActive(false); // Скрыть панель при запуске
    }

    void Update()
    {
        // Проверяем расстояние между игроком и объектом
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
            // Если панель активна и игрок удаляется, скрываем панель
            popupPanel.SetActive(false);
        }
    }

    void TogglePopup()
    {
        popupPanel.SetActive(!popupPanel.activeSelf);
    }
}
