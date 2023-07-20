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
    [SerializeField] Animator anim;

    public Vector3 finalDirection;
    public Vector3 cameraDirection;

    [SerializeField] private Vector3 velocity;

    [Header("Movement Settings")]
    [SerializeField] private float actualSpeed = 5;
    private int rotationSpeed = 720;

    [Header("State")]
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool isRunning;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isFalling;

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
        AnimationHandler();
    }

    public void Move(Vector2 inputDirection)
    {
        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;


        characterController.Move(((finalDirection * actualSpeed) + velocity) * Time.deltaTime * Time.timeScale);
    }

    private void Statehandler()
    {
        if (isGrounded)
        {
            velocity.y = -2;

            actualSpeed = isRunning ? player.runnigSpeed.Value : player.walkingSpeed.Value;

        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }


        isJumping = velocity.y > 0 ? true : false;
        isFalling = velocity.y < 0 && !isGrounded ? true : false;
    }
    private void AnimationHandler()
    {
        if (finalDirection.magnitude > 0)
        {
            if (isRunning)
            {
                anim.SetFloat("Speed", 1.5f);
            }
            else
            {
                anim.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isFalling", isFalling);
        anim.SetBool("isGrounded", isGrounded);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = player.JumpStrength.Value;
        }
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

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
