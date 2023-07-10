using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    private Player player;
    private Rigidbody rb;
    private Camera cam;

    [SerializeField] GameObject playerBody;

    private Vector3 finalDirection;
    [HideInInspector] public Vector3 cameraDirection;


    [Header("Movement Settings")]
    [SerializeField] private float groundCheckHeight = 0.2f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airMultiplier;
    private int rotationSpeed = 720;

    [Header("State")]
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isRunning;
    [SerializeField] public bool isJumping;
    [SerializeField] public bool isFalling;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckHeight, ground);

        SpeedControl();

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    public void Move(Vector2 inputDirection)
    {
        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;

        if (isGrounded)
        {
            rb.AddForce(finalDirection * player.Speed.Value * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(finalDirection * player.Speed.Value * 10f * airMultiplier, ForceMode.Force);
        }
    }
    private void HandleRotation()
    {
        if (finalDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckHeight);
    }

    void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > player.Speed.Value)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * player.Speed.Value;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * player.JumpStrength.Value, ForceMode.Impulse);
        }
    }
}
