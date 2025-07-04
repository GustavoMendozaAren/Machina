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

    private Vector3 forwardMove;
    private float rotation = 0f;
    private Quaternion quatTurn;

    private bool running;
    private bool forward;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento con W
        forward = Input.GetKey(KeyCode.W);
        running = Input.GetKey(KeyCode.LeftShift);
        speed = running ? runSpeed : walkSpeed;

        
    }

    private void FixedUpdate()
    {
        PlayerMovementForward();
        PlayerRotation();
        PlayerAnims(); 
    }

    private void PlayerMovementForward()
    {
        if (forward)
        {
            Vector3 move = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    private void PlayerRotation()
    {
        rotation = 0f;
        if (Input.GetKey(KeyCode.A))
            rotation = -rotationSpeed * Time.fixedDeltaTime;
        else if (Input.GetKey(KeyCode.D))
            rotation = rotationSpeed * Time.fixedDeltaTime;

        if (rotation != 0)
        {
            quatTurn = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * quatTurn);
        }
    }

    private void PlayerAnims()
    {
        // Animación: 0 = idle, 0.5 = caminar, 1 = correr
        float animSpeed = forward ? (running ? 1f : 0.5f) : 0f;
        animator.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);
    }
}
