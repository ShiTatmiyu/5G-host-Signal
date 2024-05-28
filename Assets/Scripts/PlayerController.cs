using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject cam;
    [SerializeField] private PlayerInput playerInput;
    private CharacterController charCon;

    [Header("Setting")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkFov;
    [SerializeField] private float runFov;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.8f;

    //Misc Variable
    private Vector3 playerVelocity;
    private bool isGrounded;

    private void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = charCon.isGrounded;

        Vector2 moveInput = playerInput.GetMoveInput().normalized;
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        float camFov;
        if (playerInput.GetRunInput())
        {
            charCon.Move(transform.TransformDirection(moveDir) * runSpeed * Time.deltaTime);
            camFov = runFov;
        }
        else
        {
            charCon.Move(transform.TransformDirection(moveDir) * walkSpeed * Time.deltaTime);
            camFov = walkFov;
        }
        cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, camFov, 4 * Time.deltaTime);
        Debug.Log(cam.GetComponent<Camera>().fieldOfView);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        charCon.Move(playerVelocity * Time.deltaTime);

        if (isGrounded && playerInput.GetJumpInput())
        {
            playerVelocity.y = jumpForce;
        }
    }
}

