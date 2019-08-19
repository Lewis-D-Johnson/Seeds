using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	//Amount away from the edge for the camera to move
	public int screenBuffer;
	public float movementSpeed;
	public float rotationSpeed;

	public bool canMove;

    void Update()
    {
		print("Mouse Position: " + Input.mousePosition);

		if (Input.mousePosition.x < screenBuffer)
		{
			transform.Translate(Vector3.left * movementSpeed);
		}
		if (Input.mousePosition.x > (Screen.width - screenBuffer))
		{
			transform.Translate(Vector3.right * movementSpeed);
		}
		if (Input.mousePosition.y < screenBuffer)
		{
			transform.Rotate(Vector3.left, -rotationSpeed);
		}
		if (Input.mousePosition.y > (Screen.height - screenBuffer))
		{
			transform.Rotate(Vector3.left, rotationSpeed);
		}
	}
}
