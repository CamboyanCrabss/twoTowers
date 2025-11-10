using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesFunctions : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float downSpeed = 2f;
    public float upSpeed = 7f;
    private float speed;
    private Transform currentPos;

    void Start()
    {
        // Al inicio, mueve a la posición inicial (pos1)
        transform.position = pos1.position;
        currentPos = pos1;
        speed = downSpeed;
    }

    void Update()
    {
        MoveToPosition();
    }

    public void SpikesOut()
    {
        // Cuando se activa SpikesOut, mueve a la posición 2 (pos2)
        if (currentPos == pos1)
        {
            speed = upSpeed;
            currentPos = pos2;
        }
    }

    public void SpikesIn()
    {
        // Cuando se activa SpikesIn, mueve a la posición 1 (pos1)
        if (currentPos == pos2)
        {
            speed = downSpeed;
            currentPos = pos1;
        }
    }

    private void MoveToPosition()
    {
        // Utiliza la función MoveTowards para suavemente moverse hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, currentPos.position, speed * Time.deltaTime);
    }
}

