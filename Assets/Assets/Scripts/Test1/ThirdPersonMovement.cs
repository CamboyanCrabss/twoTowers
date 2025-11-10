using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;

    CharacterController controller;
    float turnSmoothTime = 1f;
    float turnSmoothVelocity;

    //Movimiento
    Vector2 movement;
    public float moveSpeed;

    //Salto
    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;

    //Agacharse
    bool isCrouching = false;
    public float crouchHeight = 0.5f;
    public float standingHeight = 2f;
    public float crouchSpeedMultiplier = 0.5f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        //Jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
        }

        if (velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }
        
        controller.Move(velocity * Time.deltaTime);

        //Crouching

       
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            controller.height = crouchHeight;
            moveSpeed *= crouchSpeedMultiplier; // Reducir la velocidad al agacharse
        }
    
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            controller.height = standingHeight;
            moveSpeed /= crouchSpeedMultiplier; // Restaurar la velocidad al levantarse
        }
    }
}
