using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement2 : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float rotationSpeed = 100f;

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Rotar con A/D
        float turn = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);

        // Movimiento con W
        bool forward = Input.GetKey(KeyCode.W);
        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = running ? runSpeed : walkSpeed;

        if (forward)
        {
            Vector3 move = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + move);
        }

        // Animación: 0 = idle, 0.5 = caminar, 1 = correr
        float animSpeed = forward ? (running ? 1f : 0.5f) : 0f;
        animator.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);
    }
}
