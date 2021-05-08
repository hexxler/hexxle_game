using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityCamera : MonoBehaviour
{
    public float moveSpeed;
    public float tileplaneHeight;
    public float minDegree;
    public float maxDegree;
    public int zoomSteps;

    private InputManager inputManager;
    private Vector3 direction;
    private bool held;

    private float degreeStep;

    private void Awake()
    {
        inputManager = new InputManager();

        degreeStep = (maxDegree - minDegree) / zoomSteps;
        Camera.main.transform.Rotate(minDegree, 0, 0);
        Camera.main.orthographicSize = CalculateOrthographicSize(Camera.main.transform.rotation.eulerAngles.x);

        inputManager.CameraMovement.Zoom.Enable();
        inputManager.CameraMovement.Move.canceled += context => MoveCamera(context);
        inputManager.CameraMovement.Zoom.performed += context => ZoomCameraRotation(context);

        inputManager.CameraMovement.Move.Enable();
        inputManager.CameraMovement.Move.performed += context => MoveCamera(context);
    }

    private void Update()
    {
        if (held) 
        {
            Vector3 relative = Camera.main.transform.InverseTransformDirection(direction * moveSpeed * Time.deltaTime);
            Camera.main.transform.Translate(relative);
        }
    }

    private void ZoomCameraRotation(InputAction.CallbackContext context)
    {
        int zoomDirection = context.ReadValue<Vector2>().y > 0 ? -1 : 1;

        float newAngle = Camera.main.transform.rotation.eulerAngles.x + degreeStep * zoomDirection;

        if (minDegree <= newAngle && newAngle <= maxDegree + degreeStep)
        {
            Camera.main.transform.Rotate(degreeStep * zoomDirection, 0, 0);
            float newOrthographicSize = CalculateOrthographicSize(Camera.main.transform.rotation.eulerAngles.x);
            Camera.main.orthographicSize = newOrthographicSize;
        }
    }

    private void ZoomCameraDistance(InputAction.CallbackContext context)
    {
        int zoomDirection = context.ReadValue<Vector2>().y > 0 ? -1 : 1;

        float newAngle = Camera.main.transform.rotation.eulerAngles.x + degreeStep * zoomDirection;

        if (minDegree <= newAngle && newAngle <= maxDegree)
        {
            Camera.main.transform.Rotate(degreeStep * zoomDirection, 0, 0);
            float newOrthographicSize = CalculateOrthographicSize(Camera.main.transform.rotation.eulerAngles.x);
            Camera.main.orthographicSize = newOrthographicSize;
        }
    }

    private void MoveCamera(InputAction.CallbackContext context)
    {
        var moveVector = context.ReadValue<Vector2>();
        direction.x = moveVector.x;
        direction.z = moveVector.y;
        if (context.performed) held = true;
        if (context.canceled) held = false;
    }

    private float CalculateOrthographicSize(float angleOnX)
    {
        return (Camera.main.transform.position.y - tileplaneHeight) / Mathf.Cos(angleOnX * Mathf.Deg2Rad);
    }
}
