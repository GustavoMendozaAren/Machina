using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    float vertical;
    bool isMovVert = false;
    float horizontal;
    Vector3 move;

    float moveVertical;
    private Rigidbody rb;
    private Animator anim;

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
        vertical = Input.GetAxis("Vertical");   // W/S para moverse
        // Mover hacia adelante (W/S)
        move = transform.forward * vertical * moveSpeed * Time.fixedDeltaTime;

        if (isMovVert)
        {
            horizontal = Input.GetAxis("Horizontal"); // A/D para rotar
            // Rotar en el eje Y (A y D)
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime);
        }

        rb.MovePosition(rb.position + move);
    }

    void PlayerMoveAnimations()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMovVert = true;
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isMovVert = false;
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isMovVert = true;
            anim.SetBool("IsBacking", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isMovVert = false;
            anim.SetBool("IsBacking", false);
        }
    }
}
