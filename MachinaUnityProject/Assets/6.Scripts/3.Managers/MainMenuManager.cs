using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject[] paneles;

    [SerializeField] private GameObject blockPanel;

    private void Start()
    {
        StartCoroutine(AnimacionesDeBotones());
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
    }

    public void OptionsCloseBtn()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);

        StartCoroutine(AnimacionesDeBotones());
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

        StartCoroutine(AnimacionesDeBotones());
    }

    IEnumerator AnimacionesDeBotones()
    {
        blockPanel.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        blockPanel.SetActive(false);
    }

}
