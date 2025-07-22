using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement2 : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private Animator animator;
    private Rigidbody rb;

    private Vector3 forwardMove;
    private Quaternion quatTurn;

    private bool forward;
    private bool backward;
    private bool running;
    private float speed;

    private float SpeedForAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento con W
        forward = Input.GetKey(KeyCode.W);
        backward = Input.GetKey(KeyCode.S);
        running = Input.GetKey(KeyCode.LeftShift);
        speed = running ? runSpeed : walkSpeed;

        PlayerAnims();
    }

    private void FixedUpdate()
    {
        PlayerMovementForward();
        PlayerRotation();
    }

    private void PlayerMovementForward()
    {
        if (forward)
        {
            Vector3 move = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + move);
        }

        if (backward)
        {
            Vector3 move = transform.forward * (-speed) * Time.deltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    private void PlayerRotation()
    {
        //rotation = 0f;
        //if (Input.GetKey(KeyCode.A))
        //    rotation = -rotationSpeed * Time.fixedDeltaTime;
        //else if (Input.GetKey(KeyCode.D))
        //    rotation = rotationSpeed * Time.fixedDeltaTime;

        //if (rotation != 0)
        //{
        //    quatTurn = Quaternion.Euler(0f, rotation, 0f);
        //    rb.MoveRotation(rb.rotation * quatTurn);
        //}

        rb.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
    }

    private void PlayerAnims()
    {
        // Animación: 0 = idle, 0.5 = caminar, 1 = correr

        if (forward)
        {
            SpeedForAnim = running ? 1f : 0.5f;
        }
        else if (backward)
        {
            SpeedForAnim = -1f;
        }
        else
        {
            SpeedForAnim = 0f;
        }

        animator.SetFloat("Speed", SpeedForAnim, 0.1f, Time.deltaTime);
    }
}
