using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameButtonsTest : MonoBehaviour
{
    [SerializeField] private GameObject[] panelsMiniGame;

    public void ButonCorrect()
    {
        panelsMiniGame[0].SetActive(false);
        panelsMiniGame[1].SetActive(true);
        panelsMiniGame[2].SetActive(false);
    }

    public void ButonIncorrect()
    {
        panelsMiniGame[0].SetActive(false);
        panelsMiniGame[1].SetActive(false);
        panelsMiniGame[2].SetActive(true);
    }

    public void ButonReturnToGame()
    {
        panelsMiniGame[0].SetActive(true);
        panelsMiniGame[1].SetActive(false);
        panelsMiniGame[2].SetActive(false);
    }

}
