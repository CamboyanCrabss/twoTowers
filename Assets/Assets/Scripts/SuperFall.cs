using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFall : MonoBehaviour
{
    public Rigidbody ballRb;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ballRb.AddForce(new Vector3(0, gravity, 0));
    }
}
