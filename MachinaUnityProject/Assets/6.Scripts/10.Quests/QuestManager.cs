using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header("QUESTS")]
    [SerializeField] private Quest[] questDisponibles;

    [Header("INSPECTOR QUESTS")]
    [SerializeField] private InspectorQuestDescripcion inspectorQuestPrefab;
    [SerializeField] private Transform inspectorQuestContenedor;

    [Header("PERSONAJE QUESTS")]
    [SerializeField] private PersonajeQuestDescripcion personajeQuestPrefab;
    [SerializeField] private Transform personajeQuestContenedor;

    [Header("PANEL QUEST COMPLETADO")]
    [SerializeField] private GameObject panelQuestCompletado;
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questRecompensaOro;

    public Quest QuestPorReclamar { get; private set; }

    private void Start()
    {
        CargarQuestEnIspector();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            AniadirProgreso("M1", 1);
        }
    }

    private void CargarQuestEnIspector()
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            InspectorQuestDescripcion nuevoQuest = Instantiate(inspectorQuestPrefab, inspectorQuestContenedor);
            nuevoQuest.ConfigurarQuestUI(questDisponibles[i]);
        }
    }

    private void AniadirQuestPorCompletar(Quest questPorCompletar)
    {
        PersonajeQuestDescripcion nuevoQuest = Instantiate(personajeQuestPrefab, personajeQuestContenedor);
        nuevoQuest.ConfigurarQuestUI(questPorCompletar);
    }

    public void AniadirQuest(Quest questPorCompletar)
    {
        AniadirQuestPorCompletar(questPorCompletar);
    }

    public void ReclamarRecompensa()
    {
        if (QuestPorReclamar == null)
            return;

        MonedasManager.Instance.AnniadirMonedas(QuestPorReclamar.RecompensaOro);
        OcultarPanelQuestCompletado();
        QuestPorReclamar = null;
    }

    public void AniadirProgreso(string questID, int cantidad)
    {
        Quest questPorActualizar = QuestExiste(questID);

        if (questPorActualizar.QuestAceptado)
        {
            questPorActualizar.AniadirProgreso(cantidad);
        }
    }

    private Quest QuestExiste(string questID)
    {
        for(int i = 0;i < questDisponibles.Length; i++)
        {
            if (questDisponibles[i].ID == questID)
                return questDisponibles[i];
        }
        return null;
    }

    private void MostrarQuestCompletado(Quest questCompletado)
    {
        MostrarPanelQuestCompletado();
        questNombre.text = questCompletado.Nombre;
        questRecompensaOro.text = questCompletado.RecompensaOro.ToString();
    }

    private void QuestCompletadoRespuesta(Quest questCompletado)
    {
        QuestPorReclamar = QuestExiste(questCompletado.ID);

        if(QuestPorReclamar != null)
        {
            MostrarQuestCompletado(QuestPorReclamar);
        }
    }

    // EXTRA FOR HIDE MOUSE

    private void MostrarPanelQuestCompletado()
    {
        panelQuestCompletado.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OcultarPanelQuestCompletado()
    {
        panelQuestCompletado.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            questDisponibles[i].ResetQuest();
        }

        Quest.EventoQuestCompletado += QuestCompletadoRespuesta;
    }

    private void OnDisable()
    {
        Quest.EventoQuestCompletado -= QuestCompletadoRespuesta;
    }
}
