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
        // ���� ����� ��� �� �����������
        if (minutes > 0 || seconds > 0)
        {
            // ��������� ���������� ������ � ������ deltaTime
            gameTime += Time.deltaTime;

            if (gameTime >= 1f)
            {
                seconds--; // ��������� �������
                gameTime = 0f; // ���������� gameTime

                // ���� ������� ������ 0, ��������� ������
                if (seconds < 0)
                {
                    if (minutes > 0)
                    {
                        minutes--;  // ��������� ������
                        seconds = 59f; // ������� ����� ���������� 59
                    }
                    else
                    {
                        seconds = 0f; // ���� ������ �����������, ������ ������� �� 0
                    }
                }
            }
        }
    }
}