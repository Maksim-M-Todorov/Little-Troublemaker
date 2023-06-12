using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public AudioSource walkingSound;

    Vector3 moveDirection;

    Rigidbody rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();

        //handle drag
        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        if (walkingSound != null)
        {
            if (Time.timeScale != 0 && !walkingSound.isPlaying && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                walkingSound.Play(0);
            }

            if (Time.timeScale == 0)
            {
                walkingSound.Stop();
            }

            if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                walkingSound.Stop();
            }
        }
        
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        //in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }    
    }

    //Duo to reashearch we decided to remove the jumping, bcs why would you jump indoors.
    void Jump()
    {
        //reset y velocity
        //rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        //readyToJump = true;
    }
}
