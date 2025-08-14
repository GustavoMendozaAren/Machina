using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionInGPanel;
    [SerializeField] private GameObject controlsPanel;
    private bool isPaused = false;

    private bool cursorShow = false;

    void Start()
    {
        HideCursorMouse();
    }

    private void Update()
    {
        StandByPanelActive();

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            HideShowCursorRightClick();
        }
    }

    private void StandByPanelActive()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPaused)
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);

            ShowCursorMouse();

            isPaused = true;
        }
    }

    public void StandByPanelDeactive()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);

        HideCursorMouse();

        isPaused = false;
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
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

    public void ControlsPanelOpen()
    {
        controlsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void ControlsPanelClosed()
    {
        controlsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    // CURSOR STUFF

    public void HideCursorMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowCursorMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HideShowCursorRightClick()
    {
        cursorShow = !cursorShow;

        if (cursorShow)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
