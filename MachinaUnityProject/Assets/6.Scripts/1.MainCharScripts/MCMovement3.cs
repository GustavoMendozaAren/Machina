using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MCMovement3 : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1.65f;
    [SerializeField] private float runSpeed = 3.5f;
    [SerializeField] private float rotationSpeed = 100f;

    private Rigidbody rb;
    private Animator anim;

    private Vector3 forwardMove;
    private float rotation = 0f;
    private Quaternion quatTurn;

    private Vector3 movementInput;
    private float currentSpeed;
    private bool isRunning = false;
    private float speedValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMovementAnims();
    }

    private void FixedUpdate()
    {
        PlayermovementForward();
        PlayerRotation();
    }

    private void PlayermovementForward()
    {
        movementInput = Vector3.zero;
        currentSpeed = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            isRunning  = Input.GetKey(KeyCode.LeftShift);
            currentSpeed = isRunning ? runSpeed : walkSpeed;

            movementInput = transform.forward * currentSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movementInput);
        }
    }

    private void PlayerRotation()
    {
        rotation = 0f;
        if (Input.GetKey(KeyCode.A))
            rotation = -rotationSpeed * Time.fixedDeltaTime;
        else if (Input.GetKey(KeyCode.D))
            rotation = rotationSpeed * Time.fixedDeltaTime;

        if(rotation != 0)
        {
            quatTurn = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * quatTurn);
        }
    }

    private void PlayerMovementAnims()
    {
        speedValue = movementInput.magnitude / Time.deltaTime;
        anim.SetFloat("Speed2", speedValue);
        anim.SetBool("isRunning", isRunning);
    }
}
