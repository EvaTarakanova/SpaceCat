using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerScriot : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float minutes = 9f;
    public float seconds = 60f;
    private float gameTime;


    private void Update()
    {
        timer.text = "Left Time: " + minutes + ":" + seconds;
        // Если время еще не закончилось
        if (minutes > 0 || seconds > 0)
        {
            // Уменьшаем количество секунд с учетом deltaTime
            gameTime += Time.deltaTime;

            if (gameTime >= 1f)
            {
                seconds--; // Уменьшаем секунды
                gameTime = 0f; // Сбрасываем gameTime

                // Если секунды меньше 0, уменьшаем минуты
                if (seconds < 0)
                {
                    if (minutes > 0)
                    {
                        minutes--;  // Уменьшаем минуты
                        seconds = 59f; // Секунды снова становятся 59
                    }
                    else
                    {
                        seconds = 0f; // Если минуты закончились, ставим секунды на 0
                    }
                }
            }
        }
    }
}