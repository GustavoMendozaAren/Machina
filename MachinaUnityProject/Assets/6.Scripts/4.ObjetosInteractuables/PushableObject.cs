using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    private bool isPushing = false;
    private Transform player;
    private Rigidbody rb;
    private Vector3 offset;

    public float pushSpeed = 3f;

    Vector3 targetPos;
    Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isPushing && player != null)
        {
            // Mover el objeto con el jugador
            targetPos = player.position + offset;
            moveDir = (targetPos - transform.position);
            rb.MovePosition(transform.position + moveDir * pushSpeed * Time.deltaTime);
        }
    }

    public void StartPush(Transform playerTransform)
    {
        player = playerTransform;
        offset = transform.position - player.position;
        isPushing = true;
        rb.freezeRotation = true;
    }

    public void StopPush()
    {
        isPushing = false;
        player = null;
        rb.freezeRotation = false;
    }
}
