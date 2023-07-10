using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum MovementState
{
    Walking,
    Running,
    Air
}

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

    [SerializeField] private float groundDrag;
    [SerializeField] private float airMultiplier;
    private int rotationSpeed = 720;
    [SerializeField] private float speed;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckHeight = 0.2f;
    [SerializeField] private LayerMask ground;

    [Header("Slope handling")]
    [SerializeField] private float maxSlopeAngle;
    private RaycastHit slopeCheck;

    [Header("State")]
    public MovementState state;
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isRunning;
    [SerializeField] public bool isOnSlope;

    public float maxForce;
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
        StateHandler();

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void StateHandler()
    {
        if (isGrounded && isRunning)
        {
            state = MovementState.Running;
            speed = player.runnigSpeed.Value;
        }
        else if (isGrounded)
        {
            state = MovementState.Walking;
            speed = player.walkingSpeed.Value;
        }
        else
        {
            state = MovementState.Air;
        }
    }
    public void Move(Vector2 inputDirection)
    {
        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;

        if (IsOnSlope())
        {
            isOnSlope = true;

            rb.AddForce(GetSlopeMoveDirection() * speed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }
        else if (isGrounded)
        {
            rb.AddForce(finalDirection * speed * 10f, ForceMode.Force);
            isOnSlope = false;

        }
        else
        {
            rb.AddForce(finalDirection * speed * 10f * airMultiplier, ForceMode.Force);
            isOnSlope = false;

        }
        rb.useGravity = !IsOnSlope();

    }


    void SpeedControl()
    {
        if (IsOnSlope())
        {
            if (rb.velocity.magnitude > speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
        else
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVelocity.magnitude > speed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * speed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }
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

    private bool IsOnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeCheck, groundCheckHeight + 0.2f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeCheck.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(finalDirection, slopeCheck.normal).normalized;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (groundCheckHeight + 0.2f));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckHeight);
    }


    //character comntroller version
    //private void HandleRotation()
    //{
    //    if (finalDirection != Vector3.zero)
    //    {
    //        Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
    //        playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    //    }
    //}

}
