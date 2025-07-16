using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkSc : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject interactTxt;
    [SerializeField] private GameObject textTest;

    private bool isOnTrigger = false;
    private bool isInteracting = false;

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
    }

    private void Update()
    {
        if (isOnTrigger)
        {
            if (!isInteracting)
                interactTxt.SetActive(true);
            else
                interactTxt.SetActive(false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                isInteracting = true;
                interactTxt.SetActive(false);
                animator.SetTrigger("Talk");
                textTest.SetActive(true);
            }

            if (isInteracting)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    animator.SetTrigger("Cheer");
                    textTest.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.U))
                {
                    animator.SetTrigger("Desp");
                    textTest.SetActive(false);
                }
            }
        }
    }
}
