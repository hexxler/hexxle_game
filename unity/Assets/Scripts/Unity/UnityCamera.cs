using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityCamera : MonoBehaviour
{
    public float zoomStep;
    public float maxZoom;
    public float moveSpeed;
    public float hoverHeight;

    private InputManager inputManager;
    private Vector3 direction;
    private bool held;

    private void Awake()
    {
        inputManager = new InputManager();
        this.transform.position = new Vector3(0, CalculateYPosition(Camera.main.orthographicSize), -5);

        inputManager.CameraMovement.Zoom.Enable();
        inputManager.CameraMovement.Move.canceled += context => MoveCamera(context);
        inputManager.CameraMovement.Zoom.performed += context => ZoomCamera(context);

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

    private void ZoomCamera(InputAction.CallbackContext context)
    {
        int zoomDirection = context.ReadValue<Vector2>().y > 0 ? -1 : 1;
        float newOrthographicSize = Camera.main.orthographicSize + zoomStep * zoomDirection;

        if (0 < newOrthographicSize && newOrthographicSize < maxZoom + zoomStep)
        {
            float deltaY = CalculateYPosition(newOrthographicSize) - Camera.main.transform.position.y + hoverHeight;
            Camera.main.transform.Translate(0, deltaY, 0);
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

    private float CalculateYPosition(float orthographicSize)
    {
        float yPosition = orthographicSize * Mathf.Cos(Camera.main.transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
        return yPosition + hoverHeight;
    }
}
