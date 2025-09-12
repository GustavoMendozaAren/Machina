using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject panelDeMisiones;
    [SerializeField] private GameObject panelPersonajeDeMisiones;

    [SerializeField] private TextMeshProUGUI monedasTxt;
    private bool questState;

    [SerializeField] private CinemachineFreeLook freeLookCamera;
    private bool isCameraRotating = true;

    private void Start()
    {
        ContinueCamerarotation();
    }

    private void Update()
    {
        ActualizarUIPersonaje();

        if (Input.GetKeyDown(KeyCode.Q))
            AbrirCerrarPanelDePersonajeQuest();
    }

    private void ActualizarUIPersonaje()
    {
        monedasTxt.text = MonedasManager.Instance.MonedasTotales.ToString();
    }

    public void CerrarPanelDeMisiones()
    {
        panelDeMisiones.SetActive(false);

        OcultarCursormethod();

        ContinueCamerarotation();
    }

    private void AbrirPanelDeMisiones()
    {
        panelDeMisiones.SetActive(true);

        MostrarCursorMethod();

        StopCameraRotation();
    }

    private void AbrirCerrarPanelDePersonajeQuest()
    {
        questState = !questState;
        if (questState)
        {
            panelPersonajeDeMisiones.SetActive(true);
            MostrarCursorMethod();
        }
        else
        {
            panelPersonajeDeMisiones.SetActive(false);
            OcultarCursormethod();
        }

        AlternCameraRotation();
    }

    private void AlternCameraRotation()
    {
        isCameraRotating = !isCameraRotating;

        if (isCameraRotating)
        {
            ContinueCamerarotation();
        }
        else
        {
            StopCameraRotation();
        }
    }

    private void MostrarCursorMethod()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OcultarCursormethod()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ContinueCamerarotation()
    {
        freeLookCamera.m_XAxis.m_MaxSpeed = 220f;
        freeLookCamera.m_YAxis.m_MaxSpeed = 1.5f;
    }

    private void StopCameraRotation()
    {
        freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
        freeLookCamera.m_YAxis.m_MaxSpeed = 0f;
    }

    public void AbrirPanelInteraccion(InteraccionExtraNPC tipoInteraccion)
    {
        switch (tipoInteraccion)
        {
            case InteraccionExtraNPC.Quest:
                AbrirPanelDeMisiones();
                break;
            case InteraccionExtraNPC.Tienda:
                break;
            case InteraccionExtraNPC.Crafting:
                break;
        }
    }
}
