using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    float vertical;
    float horizontal;
    Vector3 move;

    float moveVertical;
    private Rigidbody rb;
    private Animator anim;

    private bool isRunning = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        PlayerMoveAnimations();
    }

    private void FixedUpdate()
    {
        MovimientoPersonaje();
    }

    void MovimientoPersonaje()
    {
        vertical = Input.GetAxis("Vertical");
        move = transform.forward * vertical * moveSpeed * Time.fixedDeltaTime;

        horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + move);
    }

    void PlayerMoveAnimations()
    {
        PlayerWalkAnimations();

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            moveSpeed = 3.3f;
            anim.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            moveSpeed = 1.65f;
            anim.SetBool("isRunning", false);
        }
    }

    private void PlayerWalkAnimations()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
        }

        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsBacking", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsBacking", false);
        }
    }
}
