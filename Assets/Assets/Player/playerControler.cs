using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float gravity = -9.8f;
    public float airSpeed = 4;
    public float verticalVelocity = 0;
    public float stickToGroundSpeed = -3;
    public float jumpSpeed = 50;

    Animator cmpAnimator;
    CharacterController cmpCC;

    //Doble salto
    private bool isJumping = false;
    public int maxJumps = 2;
    private int jumpCounter = 0;
    private bool isCrouching = false;
    private bool airControls = false;

    // Start is called before the first frame update
    void Start()
    {
        cmpAnimator = GetComponent<Animator>();
        cmpCC = GetComponent<CharacterController>();
    }

    void Update()
    {
        updateCrouch();
        UpdateRotation();
        UpdatePlayerVelocity();
        stickToGround();
        updateJump();
        updateAirControls();
    }

    void updateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < (maxJumps - 1))
        {
            cmpAnimator.SetTrigger("jump");
            jumpCounter++;
            isJumping = true;
            cmpAnimator.SetBool("isJumping", true);
        }

        if (cmpCC.isGrounded)
        {
            jumpCounter = 0;
            cmpAnimator.SetBool("isGrounded", true);
            cmpAnimator.SetBool("isJumping", false);
            airControls = false;
        }
        else
        {
            cmpAnimator.SetBool("isGrounded", false);
            airControls = true;
        }
    }

    void stickToGround()
    {
        if (!isJumping)
        {
            
        }
    }

    // Update is called once per frame
    void updateCrouch()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            cmpAnimator.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            cmpAnimator.SetBool("isCrouching", false);
        }
    }

    private void UpdateRotation()
    {
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseXInput * 180 * Time.deltaTime, 0);
    }

    private void UpdatePlayerVelocity()
    {
        // Accedo al input de las flechas
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Le paso al animator la velocidad de movimiento del personaje en cada eje
        cmpAnimator.SetFloat("VelZ", zInput);
        cmpAnimator.SetFloat("VelX", xInput);

        if (!cmpCC.isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        else
        {
            verticalVelocity = stickToGroundSpeed;
            //cmpCC.Move(stickToGroundSpeed * transform.up * Time.deltaTime);
        }
    }

    void updateAirControls()
    {
        if (airControls)
        {
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            Vector3 input = transform.right * xInput + transform.forward * zInput;

            input.Normalize();
            cmpCC.Move(input * airSpeed * Time.deltaTime);
        }
    }

    private void OnAnimatorMove()
    {
        if (true)
        {
            Vector3 rootMotionMove = cmpAnimator.rootPosition - this.transform.position;
            Vector3 totalMovement = rootMotionMove + Vector3.up * verticalVelocity * Time.deltaTime;
            cmpCC.Move(totalMovement);
        }
    }

    public void addJumpSpeed()
    {
        verticalVelocity = jumpSpeed;
    }

    public void activateAirControls()
    {
        airControls = true;
    }
}