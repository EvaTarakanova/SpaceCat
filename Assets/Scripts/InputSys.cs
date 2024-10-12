using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSys : MonoBehaviour
{
    public static InputSys Instance { get; private set; }

    private InputPlayerActions playerInputActions;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new InputPlayerActions();
        playerInputActions.Enable();
    }
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
