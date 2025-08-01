using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionInGPanel;
    private bool isPaused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el mouse al centro
        Cursor.visible = false; // Oculta el cursor
    }

    private void Update()
    {
        StandByPanelActive();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void StandByPanelActive()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPaused)
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            isPaused = true;
        }
    }

    public void StandByPanelDeactive()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void HideMpuseBtn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OptionsInGActive()
    {
        optionInGPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void OptionsInGameDeactive()
    {
        optionInGPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
