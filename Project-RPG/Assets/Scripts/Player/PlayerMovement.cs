using System.Collections;
using System.Collections.Generic;
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

    [Header("Movement Settings")]

    private int rotationSpeed = 720;
    [SerializeField] private float actualSpeed;
    [SerializeField] private float gravity;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckHeight = 0.2f;
    [SerializeField] private LayerMask ground;


    [Header("State")]
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isRunning;
    [SerializeField] public bool isOnSlope;

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
        //Physics.Raycast(transform.position, Vector3.down, groundCheckHeight, ground);
    }

    private void LateUpdate()
    {
        HandleRotation();
    }

    public void Move(Vector2 inputDirection)
    {
        if (isGrounded)
        {
            cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

            finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;

            gravity = -1;

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
            gravity += Physics.gravity.y;
        }


        characterController.Move((finalDirection * actualSpeed + Vector3.up * gravity * Time.fixedDeltaTime) * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            gravity = player.JumpStrength.Value;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckHeight);
    }

    private void HandleRotation()
    {
        if (finalDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleGravity()
    {

    }

}
