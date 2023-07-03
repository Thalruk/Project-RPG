using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    PlayerInputActions input;
    CharacterController controller;


    [SerializeField] Camera cam;
    [SerializeField] GameObject playerBody;

    private Vector3 finalDirection;
    private Vector3 cameraDirection;
    private Vector3 gravity = Vector3.zero;

    private int rotationSpeed = 720;
    private int jumpHeight = 5;

    [SerializeField] public bool isGrounded;
    [SerializeField] public bool isRunning;
    [SerializeField] public bool isJumping;


    private void Awake()
    {
        player = GetComponent<Player>();
        input = new PlayerInputActions();
        controller = GetComponent<CharacterController>();

    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        HandleDataEachFrame();
        HandleGravity();
        HandleJump();
        HandleMovement();
        HandleRotation();
    }

    void HandleDataEachFrame()
    {
        //better check
        isGrounded = controller.isGrounded;
        isRunning = input.Player.Sprint.ReadValue<float>() == 1 ? true : false;
    }

    private void HandleRotation()
    {
        if (finalDirection != Vector3.zero)
        {
            Debug.Log("rotate");
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputDirection = input.Player.Movement.ReadValue<Vector2>();

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

    void HandleJump()
    {
        if (isGrounded)
        {
            isJumping = false;
            gravity.y = -0.5f;
            if (input.Player.Jump.WasPressedThisFrame())
            {
                gravity.y = jumpHeight;
                isJumping = true;
            }
        }
    }

    void HandleGravity()
    {
        gravity.y += Physics.gravity.y * Time.deltaTime;
    }
}
