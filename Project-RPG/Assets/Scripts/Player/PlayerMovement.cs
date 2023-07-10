using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    private Player player;
    private Rigidbody rb;

    Camera cam;

    [SerializeField] GameObject playerBody;
    [SerializeField] Animator anim;

    private Vector3 finalDirection;
    [HideInInspector] public Vector3 cameraDirection;
    private Vector3 gravity = Vector3.zero;

    private int rotationSpeed = 720;

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
        //HandleGravity();
        //HandleRotation();
    }
    public void Move(Vector2 inputDirection)
    {
        cameraDirection = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

        finalDirection = (inputDirection.y * cameraDirection + inputDirection.x * Vector3.Cross(cameraDirection, Vector3.down)).normalized;

        rb.velocity = finalDirection * player.walkingSpeed.Value * Time.fixedDeltaTime;

    }
    private void HandleRotation()
    {
        if (finalDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(finalDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }



    public void Jump()
    {
        if (isGrounded)
        {
            gravity.y = player.jumpStrength.Value;
            isJumping = true;
            isFalling = false;
            anim.SetTrigger("Jump");
        }
    }

    void HandleGravity()
    {
        if (isGrounded)
        {
            isJumping = false;
            gravity.y = -0.5f;
            isFalling = false;
        }
        else
        {
            if (gravity.y > 0)
            {
                isJumping = true;
            }
            else
            {
                isFalling = true;
                isJumping = false;
            }
            gravity.y += Physics.gravity.y * player.gravityMultiplier.Value * Time.deltaTime;
        }
    }
}
