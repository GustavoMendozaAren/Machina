using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject[] paneles;


    [Header("BOTONES ANIMS")]
    [SerializeField] private GameObject[] botones;
    // BUTTONS

    private void Start()
    {
        StartCoroutine(AnimacionesDeBotones(true));
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsOpenBtn()
    {
        paneles[0].SetActive(false);
        paneles[1].SetActive(true);
        paneles[2].SetActive(false);

        MainMenuBtnsAnims(false);
    }

    public void OptionsCloseBtn()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);

        StartCoroutine(AnimacionesDeBotones(true));
    }

    public void CreditsOpenBtn()
    {
        paneles[0].SetActive(false);
        paneles[1].SetActive(false);
        paneles[2].SetActive(true);

        MainMenuBtnsAnims(false);
    }

    public void CreditsCloseBtn()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);

        StartCoroutine(AnimacionesDeBotones(true));
    }

    IEnumerator AnimacionesDeBotones(bool state)
    {
        yield return new WaitForSeconds(3.5f);
        MainMenuBtnsAnims(state);
    }

    private void MainMenuBtnsAnims(bool state)
    {
        botones[0].SetActive(state);
        botones[1].SetActive(state);
        botones[2].SetActive(state);
        botones[3].SetActive(!state);
    }
}
