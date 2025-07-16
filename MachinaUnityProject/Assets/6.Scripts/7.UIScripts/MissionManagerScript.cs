using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] mission1Panel;

    private NPCTalkSc npcMission1;

    private void Start()
    {
        npcMission1 = FindObjectOfType<NPCTalkSc>();
    }

    private void Update()
    {
        if (npcMission1.IsMAccepted)
        {
            StartCoroutine(MissionTxtAppear());
        }
    }

    IEnumerator MissionTxtAppear()
    {
        mission1Panel[0].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        mission1Panel[1].SetActive(true);
        yield return new WaitForSeconds(4f);
        mission1Panel[0].SetActive(false);
        mission1Panel[1].SetActive(false);
    }
}
