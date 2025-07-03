using UnityEngine;
using Cinemachine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera minigameCam;
    [SerializeField] private GameObject miniGamePanel;
    [SerializeField] private GameObject textoMiniGame;
    [SerializeField] private GameObject player;

    private bool isInRange = false;
    private bool isActive = false;

    [HideInInspector] public bool isExiting = false;

    private CinemachineFreeLook playerCamera;

    void Start()
    {
        playerCamera = FindObjectOfType<CinemachineFreeLook>();
        miniGamePanel.SetActive(false);
        isExiting = false;
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

        if(isExiting)
            ExitMinigame();
    }

    void EnterMinigame()
    {
        textoMiniGame.SetActive(false);

        isActive = true;

        // Desactivar movimiento del jugador (opcional)
        player.GetComponent<MCMovement>().enabled = false;

        // Activar minijuego UI
        miniGamePanel.SetActive(true);

        // Cambiar prioridad de cámara
        playerCamera.Priority = 5;
        minigameCam.Priority = 20;

        // Bloquear el mouse en centro
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ExitMinigame()
    {
        isActive = false;

        player.GetComponent<MCMovement>().enabled = true;

        miniGamePanel.SetActive(false);

        playerCamera.Priority = 20;
        minigameCam.Priority = 5;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isExiting = true;
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
