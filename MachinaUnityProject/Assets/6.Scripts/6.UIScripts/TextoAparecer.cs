using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextoAparecer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float initialDelay = 0.5f;
    [SerializeField] private float delayBetweenCharacters = 0.05f;
    //[SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip[] typeSounds;

    private string originalText;

    [SerializeField] private bool wantObj = false;
    [SerializeField] private GameObject[] appearObj;

    void OnEnable()
    {
        if (textComponent == null)
        {
            Debug.LogWarning("TextMeshProUGUI no asignado.");
            return;
        }

        originalText = textComponent.text;
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        textComponent.text = "";  // Oculta el texto original
        yield return new WaitForSeconds(initialDelay);

        foreach (char letter in originalText)
        {
            textComponent.text += letter;

            //if (typeSounds.Length > 0 && audioSource != null && letter != ' ')
            //{
            //    AudioClip clip = typeSounds[Random.Range(0, typeSounds.Length)];
            //    audioSource.PlayOneShot(clip);
            //}

            yield return new WaitForSeconds(delayBetweenCharacters);
        }

        if (wantObj)
        {
            for (int i = 0; i < appearObj.Length; i++)
            {
                appearObj[i].SetActive(true);
            }
        }
    }
}
