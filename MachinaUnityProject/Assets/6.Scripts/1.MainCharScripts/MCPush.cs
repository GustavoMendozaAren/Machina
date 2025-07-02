using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MCPush : MonoBehaviour
{
    [SerializeField] GameObject[] pressEImg;
    [SerializeField] Collider eCollider;
    private bool isEPressed = false;

    [SerializeField] float interactRange = 2f;

    private PushableObject currentPushable;

    Ray ray;

    private void OnTriggerEnter(Collider other)
    {
        //other = eCollider;
        if (other.CompareTag("MovObj"))
        {
            if (!isEPressed)
                pressEImg[0].SetActive(true);
            else if (isEPressed) 
                pressEImg[0].SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //other = eCollider;
        if (other.CompareTag("MovObj"))
        {
            pressEImg[0].SetActive(false);
        }
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, transform.forward * 2, Color.white);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentPushable == null)
            {
                TryStartPush();
                isEPressed = true;
                pressEImg[0].SetActive(false);
                pressEImg[1].SetActive(true);
            }
            else
            {
                isEPressed = false;
                currentPushable.StopPush();
                currentPushable = null;
                pressEImg[1].SetActive(false);
            }
        }
    }

    void TryStartPush()
    {
        ray = new Ray(transform.position + Vector3.up, transform.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            PushableObject pushable = hit.collider.GetComponent<PushableObject>();
            if (pushable != null)
            {
                currentPushable = pushable;
                currentPushable.StartPush(transform);
            }
        }
    }
}
