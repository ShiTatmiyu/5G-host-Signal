using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerAction playerAction;

    void Start()
    {
        playerAction = new PlayerAction();
        playerAction.Player.Enable();
    }

    public Vector2 GetLookInput()
    {
        return playerAction.Player.Look.ReadValue<Vector2>();
    }
    
    public Vector2 GetMoveInput()
    {
        return playerAction.Player.Move.ReadValue<Vector2>();
    }

    public bool GetRunInput()
    {
        return playerAction.Player.Sprint.WasPressedThisFrame();
    }

    public bool GetJumpInput()
    {
        return playerAction.Player.Jump.WasPerformedThisFrame();
    }
}
