using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject newMissionTitle;
    [SerializeField] private GameObject[] missionsTxts;

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
        newMissionTitle.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        missionsTxts[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        newMissionTitle.SetActive(false);
        //mission1Panel[1].SetActive(false);
    }
}
