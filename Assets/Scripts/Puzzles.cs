using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleManager : MonoBehaviour {
    public GameObject[] puzzlePieces; // ћассив всех пазлов
    public Transform[] targetPositions; // ћассив целевых позиций дл€ пазлов
    //private bool test = false;
    private void OnEnable()
    {
        // Ќайти все целевые позиции с тегом "TargetPosition"
        targetPositions = GameObject.FindGameObjectsWithTag("TargetPosition")
                                    .Select(obj => obj.transform)
                                    .ToArray();
        HashSet<Vector3> uniquePositions = new HashSet<Vector3>();
        foreach (var position in targetPositions)
        {
            if (!uniquePositions.Add(position.position))
            {
                Debug.LogError("ƒубликат позиции найден: " + position.position);
            }
        }

    }
    void Start()
    {

        // ”бедитьс€, что количество целевых позиций соответствует количеству пазлов
        if (puzzlePieces.Length > targetPositions.Length)
        {
            Debug.LogError("Ќедостаточно целевых позиций дл€ всех пазлов!" + targetPositions.Length);
            return; // «авершаем выполнение, если не хватает позиций
        }

        // ѕеремешать позиции
        Shuffle(targetPositions);

        // ”становить каждый пазл на одну из перемешанных позиций
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            // ”станавливаем локальную позицию каждого пазла относительно родительского объекта
            puzzlePieces[i].transform.localPosition = targetPositions[i].localPosition;

            // ƒополнительно случайно поворачиваем каждый пазл
            int[] rotate = { 0, 90, 180, 270 };
            puzzlePieces[i].transform.Rotate(0, 0, rotate[Random.Range(0, rotate.Length)]);

            // Ћог дл€ проверки
            Debug.Log($"ѕазл {puzzlePieces[i].name} установлен на локальную позицию {puzzlePieces[i].transform.localPosition}, цель: {targetPositions[i].localPosition}");
        }
    }

    // ћетод дл€ перемешивани€ массива
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