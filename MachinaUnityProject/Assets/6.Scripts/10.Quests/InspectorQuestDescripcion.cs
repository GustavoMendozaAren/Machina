using TMPro;
using UnityEngine;

public class InspectorQuestDescripcion : QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI questRecompensa;

    public override void ConfigurarQuestUI(Quest quest)
    {
        base.ConfigurarQuestUI(quest);
        questRecompensa.text = $"-{quest.RecompensaOro} credits";
    }

    public void AceptarQuest()
    {
        if (QuestPorCompletar == null)
            return;

        QuestManager.Instance.AniadirQuest(QuestPorCompletar);
        gameObject.SetActive(false);
    }
}
