using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    PlayerInputActions input;
    Vector3 gravity = Vector3.zero;

    [SerializeField] Camera cam;
    [SerializeField] GameObject playerBody;

    private Vector3 finalDirection;
    private Vector3 cameraDirection;

    [SerializeField] private int walkingSpeed;
    [SerializeField] private int runningSpeed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private int jumpHeight;

    [SerializeField] private bool isGrounded;
    private bool isRunning;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new PlayerInputActions();
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
        HandleRotation();
        HandleMovement();
        HandleGravity();
        HandleJump();
    }


    void HandleDataEachFrame()
    {
        //better check
        isGrounded = controller.isGrounded;
        isRunning = input.Player.Sprint.ReadValue<float>() == 1 ? true : false;
    }
    private void HandleRotation()
    {
        if(finalDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void HandleMovement()
    {
        Vector2 inputDirection = input.Player.Movement.ReadValue<Vector2>();

        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;

        if (isGrounded && input.Player.Jump.WasPressedThisFrame())
        {
            gravity.y = jumpHeight;
            Debug.Log("I WANT TO JUMP");
        }

        controller.Move((finalDirection * walkingSpeed + gravity) * Time.deltaTime);
    }

    void HandleJump()
    {
     
    }
    void HandleGravity()
    {
        if (isGrounded)
        {
            gravity.y = -0.1f;
        }
        else
        {
            gravity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
   
}
