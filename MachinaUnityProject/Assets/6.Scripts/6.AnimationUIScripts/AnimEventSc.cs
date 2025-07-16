using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventSc : MonoBehaviour
{
    [SerializeField] private GameObject[] textosAppear;

    private void AppearTxts()
    {
        for (int i = 0; i < textosAppear.Length; i++)
        {
            textosAppear[i].SetActive(true);
        }
    }
}
