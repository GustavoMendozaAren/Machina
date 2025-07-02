using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MCPush : MonoBehaviour
{
    [SerializeField] GameObject pressEImg;
    [SerializeField] Collider eCollider;

    [SerializeField] float interactRange = 2f;

    private PushableObject currentPushable;

    Ray ray;

    private void OnTriggerEnter(Collider other)
    {
        //other = eCollider;
        if (other.CompareTag("MovObj"))
        {
            pressEImg.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //other = eCollider;
        if (other.CompareTag("MovObj"))
        {
            pressEImg.SetActive(false);
        }
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, transform.forward * 2, Color.white);
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressEImg.SetActive(false);
            if (currentPushable == null)
            {
                TryStartPush();
            }
            else
            {
                currentPushable.StopPush();
                currentPushable = null;
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
