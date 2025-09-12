using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScaler : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.1f; // Ajusta este valor para controlar el tamaño
    [SerializeField] private float minScale = 0.5f;    // Tamaño mínimo
    [SerializeField] private float maxScale = 3f;      // Tamaño máximo

    void LateUpdate()
    {
        // Asegura que el sprite mire hacia la cámara
        Vector3 targetPosition = Camera.main.transform.position;
        targetPosition.y = transform.position.y; // Mantiene la altura
        transform.LookAt(targetPosition);

        // Calcula la distancia entre el sprite y la cámara
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Calcula el nuevo tamaño basado en la distancia
        float scale = Mathf.Clamp(distance * scaleFactor, minScale, maxScale);

        // Aplica el nuevo tamaño
        transform.localScale = new Vector3(scale, scale, scale);
    }


}
