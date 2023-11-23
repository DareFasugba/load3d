using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 100;
    public float rotationSpeed = 350;
    public float jumpSpeed = 40;
    private float ySpeed;
    private CharacterController conn;
    private Animator animator;
    public bool isGrounded;
    public Joystick joy;

    // Start is called before the first frame update
    void Start()
    {
        conn = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void PerformJump()
{
    if (isGrounded) // Ensure the character is on the ground to jump
    {
        ySpeed = jumpSpeed;
        isGrounded = false;
    }
}

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = 0f;
        float verticalMove = 0f;

        if (joy != null && joy.isActiveAndEnabled)
        {
            // Use joystick input if available
            horizontalMove = joy.Horizontal;
            verticalMove = joy.Vertical;
        }
        else
        {
            // Use keyboard input if joystick is not active
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");
        }

        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);

        if (moveDirection.magnitude > 0.1f)
        {
            // Normalize and clamp the magnitude to ensure consistent speed.
            moveDirection.Normalize();
            float magnitude = Mathf.Clamp01(moveDirection.magnitude);

            // Apply movement.
            conn.SimpleMove(moveDirection * speed);
            animator.SetBool("IsMoving", true);

            // Rotate the character to face the movement direction.
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        // Apply gravity
        Physics.gravity = new Vector3(0, -60.0f, 0);
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // Check for jumping input and reset ySpeed if grounded
        if (conn.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            if (Input.GetButtonDown("Jump"))
            {
              PerformJump();
            }
        }

        // Apply vertical movement
        Vector3 vel = moveDirection;
        vel.y = ySpeed;
        conn.Move(vel * Time.deltaTime);
    }
}