using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
	public float minX = -80f;
	public float maxX = 80f;

	public float sensitivity;
	public Camera cam;

	float rotY = 0f;
	float rotX = 0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    void Update()
    {
        Vector2 lookInput = playerInput.GetLookInput();
		rotY += lookInput.x * sensitivity;
		rotX += lookInput.y * sensitivity;

		rotX = Mathf.Clamp(rotX, minX, maxX);

		transform.localEulerAngles = new Vector3(0, rotY, 0);
		cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
        	//Mistake happened here vvvv
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (Cursor.visible && Input.GetMouseButtonDown(1))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}
