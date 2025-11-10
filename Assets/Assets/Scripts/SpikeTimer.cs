using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTimer : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float downSpeed = 2f;
    public float upSpeed = 7f;
    public float tiempoIn = 10f;
    public float tiempoOut = 5f;
    private float speed;
    private Transform currentPos;

    void Start()
    {
        // Al inicio, mueve a la posición inicial (pos1)
        transform.position = pos1.position;
        currentPos = pos1;
        speed = downSpeed;
        StartCoroutine(Timer());
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPos.position, speed * Time.deltaTime);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoOut);
            speed = upSpeed;
            currentPos = pos2;
            yield return new WaitForSeconds(tiempoIn);
            speed = downSpeed;
            currentPos = pos1;
        }
    }
}
