using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAndCamera : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el mouse al centro
        Cursor.visible = false; // Oculta el cursor
    }

    void Update()
    {
        // Desbloquear con ESC por si necesitas salir del modo juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
