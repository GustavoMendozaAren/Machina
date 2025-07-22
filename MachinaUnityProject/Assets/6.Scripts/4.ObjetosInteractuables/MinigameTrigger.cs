using UnityEngine;
using Cinemachine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera minigameCam;
    [SerializeField] private GameObject miniGamePanel;
    [SerializeField] private GameObject textoMiniGame;

    private bool isInRange = false;
    private bool isActive = false;

    private CinemachineFreeLook playerCamera;
    private MCMovement2 playerMov;

    void Start()
    {
        playerCamera = FindObjectOfType<CinemachineFreeLook>();
        playerMov = FindObjectOfType<MCMovement2>();

        miniGamePanel.SetActive(false);
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isActive)
            {
                EnterMinigame();
            }
            else
            {
                ExitMinigame();
            }
        }
    }

    void EnterMinigame()
    {
        playerMov.enabled = false;

        textoMiniGame.SetActive(false);

        isActive = true;

        // Activar minijuego UI
        miniGamePanel.SetActive(true);

        // Cambiar prioridad de cámara
        playerCamera.Priority = 5;
        minigameCam.Priority = 20;

        // Bloquear el mouse en centro
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitMinigame()
    {
        playerMov.enabled = true;

        isActive = false;

        miniGamePanel.SetActive(false);

        playerCamera.Priority = 20;
        minigameCam.Priority = 5;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoMiniGame.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoMiniGame.SetActive(false);
            isInRange = false;
            if (isActive) ExitMinigame();
        }
    }
}
