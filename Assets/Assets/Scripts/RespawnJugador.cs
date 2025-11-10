using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnJugador : MonoBehaviour
{
    private Vector3 cheekpoint;
    public float MaxCheekpoints = 6f;
    private bool canSave = true;
    private float currentCheekpoint = 6f;

    void Start()
    {
        currentCheekpoint = MaxCheekpoints;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canSave && currentCheekpoint >= 1)
        {
            cheekpoint = transform.position;
            currentCheekpoint --;
        }
    }

    void OnTriggerEnter(Collider coll )
    {
        if (coll.CompareTag("Danger"))
        {
            transform.position = cheekpoint;
           
        }
        if (coll.CompareTag("noCheekpoint"))
        {
            canSave = false;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("noCheekpoint"))
        {
            canSave = true;
        }
    }
}
