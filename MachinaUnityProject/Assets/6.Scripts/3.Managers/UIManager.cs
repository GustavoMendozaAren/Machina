using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject panelDeMisiones;
    [SerializeField] private GameObject panelPersonajeDeMisiones;

    [SerializeField] private TextMeshProUGUI monedasTxt;

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

    public void AbrirCerrarPanelDeMisiones()
    {
        panelDeMisiones.SetActive(!panelDeMisiones.activeSelf);
    }

    private void AbrirCerrarPanelDePersonajeQuest()
    {
        panelPersonajeDeMisiones.SetActive(!panelPersonajeDeMisiones.activeSelf);
    }

    public void AbrirPanelInteraccion(InteraccionExtraNPC tipoInteraccion)
    {
        switch (tipoInteraccion)
        {
            case InteraccionExtraNPC.Quest:
                AbrirCerrarPanelDeMisiones();
                break;
            case InteraccionExtraNPC.Tienda:
                break;
            case InteraccionExtraNPC.Crafting:
                break;
        }
    }
}
