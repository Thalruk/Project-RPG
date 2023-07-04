using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    private Player player;
    private CharacterController controller;


    Camera cam;
    [SerializeField] GameObject playerBody;
    [SerializeField] GameObject groundCheck;

    private Vector3 finalDirection;
    [HideInInspector] public Vector3 cameraDirection;
    private Vector3 gravity = Vector3.zero;

    private float pushForce = 0.1f;

    private int rotationSpeed = 720;
    private int jumpHeight = 7;

    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isRunning;
    [SerializeField] public bool isJumping;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        player = GetComponent<Player>();
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }


    private void Update()
    {
        HandleDataEachFrame();
        HandleGravity();
        HandleRotation();
    }

    void HandleDataEachFrame()
    {
        //better check
        isGrounded = controller.isGrounded;

    }

    private void HandleRotation()
    {
        if (finalDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector2 inputDirection)
    {

        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;


        if (isRunning && !isJumping)
        {
            controller.Move((finalDirection * player.runningSpeed.Value + gravity) * Time.deltaTime);
        }
        else
        {
            controller.Move((finalDirection * player.walkingSpeed.Value + gravity) * Time.deltaTime);
        }
    }

    public void Jump()
    {
        gravity.y = jumpHeight;
        isJumping = true;
    }

    void HandleGravity()
    {
        if (isGrounded)
        {
            isJumping = false;
            gravity.y = -0.5f;
        }
        else
        {
            gravity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigid = hit.collider.attachedRigidbody;

        if (rigid != null)
        {
            Vector3 forceDirection = new Vector3(hit.gameObject.transform.position.x - transform.position.x, 0, hit.gameObject.transform.position.z - transform.position.z).normalized;
            rigid.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Force);

        }

    }
}
