using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    [Header("Movement")]
    private float moveSpeed;

    [SerializeField]
    private float groundDrag;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float jumpCooldown;
    [SerializeField]
    private float airMultiplier;
    private bool readyToJump;

    [SerializeField]
    [Header("Keybinds")]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    [Header("Ground Check")]
    private float PlayerHeight;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool grounded;

    [SerializeField]
    private Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private bool wasGrounded;
    private bool wasFalling;
    private float StartOfFall;

    [SerializeField]
    private float minimumFall = 2f;

    [SerializeField]
    private PlayerHealth _playerHealth;

    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void CustomInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void FixedUpdate()
    {
        if(!wasFalling && IsFalling())
        {
            StartOfFall = transform.position.y;
        }

        if(!wasGrounded && grounded)
        {
            float fallDistance = StartOfFall - transform.position.y;
            if(fallDistance > minimumFall)
            {
                Debug.Log("Take Damage " + fallDistance);
                _playerHealth.TakeDamage(fallDistance);
            }
        }

        wasGrounded = grounded;
        wasFalling = IsFalling();

        MovePlayer();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.3f, whatIsGround);

        CustomInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            if(moveDirection != Vector3.zero)
            {
                if (_audioSource.isPlaying) return;

                _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
            }
            
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }


    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private bool IsFalling()
    {
        return (!grounded && rb.velocity.y < 0);
    }
}
