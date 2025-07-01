using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject[] paneles;

    // BUTTONS

    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsOpenBtn()
    {
        paneles[0].SetActive(false);
        paneles[1].SetActive(true);
        paneles[2].SetActive(false);
    }

    public void OptionsCloseBtn()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);
    }

    public void CreditsOpenBtn()
    {
        paneles[0].SetActive(false);
        paneles[1].SetActive(false);
        paneles[2].SetActive(true);
    }

    public void CreditsCloseBtn()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);
    }
}
