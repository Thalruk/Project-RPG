using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    private Player player;
    private CharacterController characterController;
    private Camera cam;

    [SerializeField] GameObject playerBody;

    private Vector3 finalDirection;
    [HideInInspector] public Vector3 cameraDirection;

    [SerializeField] private Vector3 velocity;

    [Header("Movement Settings")]
    [SerializeField] private float actualSpeed = 5;
    private int rotationSpeed = 720;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckHeight = 0.2f;
    [SerializeField] private LayerMask ground;


    [Header("State")]
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isRunning;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
        Statehandler();
        //Physics.Raycast(transform.position, Vector3.down, groundCheckHeight, ground);
    }

    public void Move(Vector2 inputDirection)
    {
        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;


        characterController.Move((finalDirection * actualSpeed + velocity) * Time.fixedDeltaTime);
    }

    private void Statehandler()
    {
        if (isGrounded)
        {
            velocity.y = -2;

            if (isRunning)
            {
                actualSpeed = player.runnigSpeed.Value;
            }
            else
            {
                actualSpeed = player.walkingSpeed.Value;
            }
        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = player.JumpStrength.Value;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckHeight);
    }

    private void LateUpdate()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (finalDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
