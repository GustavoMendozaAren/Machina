using TMPro;
using UnityEngine;

public class InspectorQuestDescripcion : QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI questRecompensa;

    public override void ConfigurarQuestUI(Quest quest)
    {
        base.ConfigurarQuestUI(quest);
        questRecompensa.text = $"Credits : {quest.RecompensaOro}";
    }

    public void AceptarQuest()
    {
        if (QuestPorCompletar == null)
            return;

        QuestPorCompletar.QuestAceptado = true;
        QuestManager.Instance.AniadirQuest(QuestPorCompletar);
        gameObject.SetActive(false);
    }
}
