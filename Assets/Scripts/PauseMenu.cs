using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseOverlay;

    private bool isPaused = false;

    public AudioSource musicSource;
    private float originalVolume;

    public bool IsPaused()
    {
        return isPaused;
    }

    void Start()
    {
        // ��������� ���� ����� � ���������� ��� ������
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
        // ��������� ������������ ���������
        if (musicSource != null)
        {
            originalVolume = musicSource.volume;
        }
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
        Time.timeScale = 0f; // ������������� �����
        isPaused = true;

        // ������������� ��������� ������
        if (musicSource != null)
        {
            musicSource.volume = originalVolume * 0.5f; // �������� ��������� �� 50%
        }

        // ������������� ������� ���� ����� � ����� ������
        SetMenuPosition();

        // �������� ���� ����� � ����������
        pauseMenu.SetActive(true);
        pauseOverlay.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // ������������ �����
        isPaused = false;

        // ��������������� ��������� ������
        if (musicSource != null)
        {
            musicSource.volume = originalVolume; // ��������������� ������������ ���������
        }

        // ��������� ���� ����� � ����������
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // ������������ �����
        SceneManager.LoadScene("MainGame");
    }

    private void SetMenuPosition()
    {
        // ������������� ������� ���� ����� � ����� ������ (��������� ������)
        Vector3 cameraPosition = Camera.main.transform.position;
        pauseMenu.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 1); // ��������� Z, ���� �����
        //pauseOverlay.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 1); // ��� ����� ��������� Z
    }
}
