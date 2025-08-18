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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void AbrirPanelDeMisiones()
    {
        panelDeMisiones.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void AbrirCerrarPanelDePersonajeQuest()
    {
        questState = !questState;
        if (questState)
        {
            panelPersonajeDeMisiones.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            panelPersonajeDeMisiones.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
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
