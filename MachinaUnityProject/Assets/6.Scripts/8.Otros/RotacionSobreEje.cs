using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionSobreEje : MonoBehaviour
{
    [SerializeField] private float velocidadRotacion = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }

}
