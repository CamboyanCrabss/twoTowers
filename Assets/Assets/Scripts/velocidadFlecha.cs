using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocidadFlecha : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidad = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * velocidad;
    }
}
