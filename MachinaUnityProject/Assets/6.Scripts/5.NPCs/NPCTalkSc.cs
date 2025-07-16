using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NPCTalkSc : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject interactTxt;
    [SerializeField] private GameObject[] textTest;
    [SerializeField] private GameObject[] textFlechas;

    private bool isOnTrigger = false;
    private bool isInteracting = false;
    private int options = 1;

    [HideInInspector] public bool IsMAccepted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isOnTrigger = false;
        isInteracting = false;
        interactTxt.SetActive(false);
        ActiveDeactiveTxt(false);
        textFlechas[0].SetActive(false);
        textFlechas[1].SetActive(false);
    }

    private void Update()
    {
        if (isOnTrigger && !IsMAccepted)
        {
            if (!isInteracting)
                interactTxt.SetActive(true);
            else
                interactTxt.SetActive(false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                options = 1;
                isInteracting = true;
                interactTxt.SetActive(false);
                animator.SetTrigger("Talk");
                ActiveDeactiveTxt(true);
            }

            if (isInteracting)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    textFlechas[0].SetActive(true);
                    textFlechas[1].SetActive(false);
                    options = 1;
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    textFlechas[0].SetActive(false);
                    textFlechas[1].SetActive(true);
                    options = 2;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(options == 1)
                    {
                        animator.SetTrigger("Cheer");
                        ActiveDeactiveTxt(false);
                        IsMAccepted = true;
                    }
                    else
                    {
                        animator.SetTrigger("Desp");
                        ActiveDeactiveTxt(false);
                    }
                }
            }
        }
    }

    private void ActiveDeactiveTxt(bool state)
    {
        textTest[0].SetActive(state);
        textTest[1].SetActive(state);
        textTest[2].SetActive(state);
    }
}
