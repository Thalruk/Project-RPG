using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    PlayerInputActions input;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] InventoryManager inventoryManager;

    void Awake()
    {
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
        playerMovement.isRunning = input.Player.Sprint.ReadValue<float>() == 1 ? true : false;

        if (input.Player.Jump.WasPressedThisFrame())
        {
            playerMovement.Jump();
        }

        playerMovement.Move(input.Player.Movement.ReadValue<Vector2>());

        if(input.Player.Inventory.WasPressedThisFrame())
        {
            inventoryManager.ToggleInventory();
        }
    }
}
