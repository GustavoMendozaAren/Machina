using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogoManager : Singleton<DialogoManager>
{
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TextMeshProUGUI npcNombreTxt;
    [SerializeField] private TextMeshProUGUI npcConversacionTxt;

    public NPCInteraccion NPCDisponible {  get; set; }

    private Queue<string> dialogosSecuencia;
    private bool dialogoAnimado;
    private bool despedidaMostrada;

    private void Start()
    {
        dialogosSecuencia = new Queue<string>();
    }

    private void Update()
    {
        if (NPCDisponible == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ConfigurarPanel(NPCDisponible.Dialogo);
            NPCDisponible.npcInteractTxt.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (despedidaMostrada)
            {
                AbrirCerrarPanelDialgo(false);
                despedidaMostrada = false;
                return;
            }

            if (dialogoAnimado)
            {
                ContinuarDialogo();
            }
        }
    }

    public void AbrirCerrarPanelDialgo(bool estado)
    {
        panelDialogo.SetActive(estado);
    }

    private void ConfigurarPanel(NPCDialogo npcDialogo)
    {
        AbrirCerrarPanelDialgo(true);
        CargarDialgosSecuencia(npcDialogo);

        npcNombreTxt.text = $"{npcDialogo.Nombre}:";

        MostrarTextoConAnimacion(npcDialogo.Saludo);
    }

    private void CargarDialgosSecuencia(NPCDialogo npcDialogo)
    {
        if(npcDialogo.Conversacion == null || npcDialogo.Conversacion.Length <= 0)
        {
            return;
        }

        for(int i = 0; i < npcDialogo.Conversacion.Length; i++)
        {
            dialogosSecuencia.Enqueue(npcDialogo.Conversacion[i].Oracion);
        }
    }

    private void ContinuarDialogo()
    {
        if (NPCDisponible == null) 
            return;

        if (despedidaMostrada)
            return;

        if(dialogosSecuencia.Count == 0)
        {
            string despedida = NPCDisponible.Dialogo.Despedida;
            MostrarTextoConAnimacion (despedida);
            despedidaMostrada = true;
            return;
        }

        string siguienteDialogo = dialogosSecuencia.Dequeue();
        MostrarTextoConAnimacion(siguienteDialogo);
    }

    private IEnumerator AnimarTexto(string oracion)
    {
        dialogoAnimado = false;

        npcConversacionTxt.text = "";
        char[] letras = oracion.ToCharArray();
        for(int i = 0;i < letras.Length; i++)
        {
            npcConversacionTxt.text += letras[i];
            yield return new WaitForSeconds(0.03f);
        }

        dialogoAnimado = true;
    }

    private void MostrarTextoConAnimacion(string oracion)
    {
        StartCoroutine(AnimarTexto(oracion));
    }
}
