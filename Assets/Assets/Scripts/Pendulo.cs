using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{
    public float oscillationSpeed = 2f;
    public float oscillationAmplitude = 45f; 
    public Vector3 oscillationAxis = Vector3.forward;
    private Quaternion initialRotation;

    void Start()
    {
        
        initialRotation = transform.rotation;
    }

    void Update()
    {
        
        float rotationOffset = oscillationAmplitude * Mathf.Sin(Time.time * oscillationSpeed);

       
        Quaternion oscillation = Quaternion.AngleAxis(rotationOffset, oscillationAxis);
        transform.rotation = initialRotation * oscillation;

    }
}
