using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int movementSpeed;
    public int rotateSpeed;

    public Transform respawn;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = respawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementS();
    }

    public void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Danger"))
        {
            transform.position = respawn.position;
        }
    }

    public void MovementS()
    {
        float zInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Vector3 movementVector = new Vector3(0, 0, zInput);
        Vector3 rotationVector = new Vector3(0, xInput, 0);

        this.transform.Translate(movementVector * movementSpeed * Time.deltaTime);
        this.transform.Rotate(rotationVector * rotateSpeed * Time.deltaTime);
    }
}
