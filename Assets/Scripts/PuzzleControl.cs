using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour {
    private static Puzzles selectedPuzzle; // Текущий выбранный пазл

    private void OnMouseOver()
    {
        // Проверка нажатия правой кнопки мыши
        if (Input.GetMouseButtonDown(1))
        {
            // Вращаем пазл на 90 градусов
            transform.Rotate(0, 0, 90);
        }

        // Проверка нажатия левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedPuzzle == null)
            {
                // Если ничего не выбрано, выбираем текущий пазл
                selectedPuzzle = this;
            }
            else
            {
                // Если выбран другой пазл, меняем их местами
                SwapPositions(selectedPuzzle, this);
                selectedPuzzle = null; // Сбрасываем выбранный пазл
            }
        }
    }

    private void SwapPositions(Puzzles puzzle1, Puzzles puzzle2)
    {
        // Сохраняем текущую позицию первого пазла
        Vector3 tempPosition = puzzle1.transform.position;

        // Перемещаем первый пазл на позицию второго
        puzzle1.transform.position = puzzle2.transform.position;

        // Перемещаем второй пазл на сохранённую позицию первого
        puzzle2.transform.position = tempPosition;
    }
}