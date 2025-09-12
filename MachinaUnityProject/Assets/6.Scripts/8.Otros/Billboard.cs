using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 targetPosition = Camera.main.transform.position;
        targetPosition.y = transform.position.y; // Mantiene la altura
        transform.LookAt(targetPosition);
    }

}
