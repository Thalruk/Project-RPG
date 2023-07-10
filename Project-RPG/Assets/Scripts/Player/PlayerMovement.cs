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
    [SerializeField] private float speed;

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

    void StateHandler()
    {
        if (isGrounded && isRunning)
        {
            speed = player.runnigSpeed.Value;
        }
        else if (isGrounded)
        {
            speed = player.walkingSpeed.Value;
        }
    }
    public void Move(Vector2 inputDirection)
    {
        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;

        Debug.Log(finalDirection);

        if (isGrounded)
        {
            characterController.Move((finalDirection + Physics.gravity) * player.walkingSpeed.Value * Time.fixedDeltaTime);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {

        }
    }

    private void OnDrawGizmos()
    {
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
