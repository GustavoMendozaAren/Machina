using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el mouse al centro
        Cursor.visible = false; // Oculta el cursor
    }

    private void Update()
    {
        PausePanelActive();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void PausePanelActive()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PausePanelDeactive()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
