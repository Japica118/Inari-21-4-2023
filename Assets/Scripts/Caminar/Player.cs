using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private CharacterController controller;
    private Animator anim;

    [SerializeField] private float speed;
    public bool isplayerTalking = true;
    public float gravity = -9.81f;

    public LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    public Transform groundSensor;
    public float sensorRadius;

    private float currentVelocity;
    [SerializeField] private float smoothTime;

    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxisRaw("Vertical");
        anim.SetFloat("VelZ", z);

        float x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("VelX", x);

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, groundMask);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (movement != Vector3.zero && !isplayerTalking)
        {
            // Determine the target angle based on the movement input
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;

            // Smoothly rotate the character towards the target angle
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            // Calculate the move direction based on the target angle
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Calculate the movement speed based on the input and the character's speed
            float moveSpeed = Mathf.Max(Mathf.Abs(Input.GetAxisRaw("Horizontal")), Mathf.Abs(Input.GetAxisRaw("Vertical")));
            if (moveSpeed > 1f)
            {
                moveSpeed = 1f;
            }
            movement = moveDirection * moveSpeed * speed;

            // Apply gravity if the character is grounded
            if (isGrounded)
            {
                playerVelocity.y = 0f;
            }
            playerVelocity.y += gravity * Time.deltaTime;

            // Move the character
            controller.Move((movement + playerVelocity) * Time.deltaTime);
        }
    }

    // Method to deny the player's movement
    public void Freeze()
    {
        isplayerTalking = true;
        // Set the player's velocity to zero to stop their movement
        playerVelocity = Vector3.zero;
    }

    // Method to allow the player's movement
    public void Unfreeze()
    {
        isplayerTalking = false;
    }
}