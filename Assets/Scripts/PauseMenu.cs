using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseOverlay;

    private bool isPaused = false;

    public bool IsPaused()
    {
        return isPaused;
    }

    void Start()
    {
        // Выключаем меню паузы и затемнение при старте
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Останавливаем время
        isPaused = true;

        // Устанавливаем позицию меню паузы в центр камеры
        SetMenuPosition();

        // Включаем меню паузы и затемнение
        pauseMenu.SetActive(true);
        pauseOverlay.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Возобновляем время
        isPaused = false;

        // Отключаем меню паузы и затемнение
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Возобновляем время
        SceneManager.LoadScene("MainGame");
    }

    private void SetMenuPosition()
    {
        // Устанавливаем позицию меню паузы в центр экрана (положение камеры)
        Vector3 cameraPosition = Camera.main.transform.position;
        pauseMenu.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 1); // Настройте Z, если нужно
        //pauseOverlay.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 1); // или также настройте Z
    }
}
