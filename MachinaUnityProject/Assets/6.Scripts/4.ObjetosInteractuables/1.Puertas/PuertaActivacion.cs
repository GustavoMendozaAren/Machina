using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaActivacion : MonoBehaviour
{
    [SerializeField] private float startY = 0f;       // Posición inicial en Y
    [SerializeField] private float endY = 3f;         // Posición final en Y
    [SerializeField] private float speed = 2f;        // Velocidad del movimiento

    private bool isMoving = false;
    private float targetY;

    private Vector3 current;
    private float newY;

    [HideInInspector] public bool isDoorOpen = false;

    void Start()
    {
        // Asegura que comience en la posición inicial
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, startY, pos.z);
    }

    void Update()
    {
        if (isDoorOpen)
        {
            targetY = endY;
            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            targetY = startY;
            isMoving = true;
        }

        if (isMoving)
        {
            current = transform.position;
            newY = Mathf.MoveTowards(current.y, targetY, speed * Time.deltaTime);
            transform.position = new Vector3(current.x, newY, current.z);

            if (Mathf.Approximately(newY, targetY))
            {
                isMoving = false; // Detener movimiento al llegar
            }
        }
    }
}
