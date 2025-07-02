using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCPush : MonoBehaviour
{
    [SerializeField] float interactRange = 2f;
    public KeyCode interactKey = KeyCode.E;

    private PushableObject currentPushable;

    Ray ray;
    PushableObject pushable;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
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
        Debug.DrawRay(transform.position, transform.forward * 2, Color.white);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            pushable = hit.collider.GetComponent<PushableObject>();
            if (pushable != null)
            {
                currentPushable = pushable;
                currentPushable.StartPush(transform);
            }
        }
    }
}
