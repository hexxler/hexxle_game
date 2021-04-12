using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityCamera : MonoBehaviour
{
    public float zoomStep;
    public float maxZoom;
    public float moveSpeed;

    private InputManager inputManager;
    private Vector3 direction;
    private bool held;

    private void Awake()
    {
        inputManager = new InputManager();

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

        if (0 < newOrthographicSize && newOrthographicSize < maxZoom + zoomStep)  Camera.main.orthographicSize = newOrthographicSize;
    }

    private void MoveCamera(InputAction.CallbackContext context)
    {
        var moveVector = context.ReadValue<Vector2>();
        direction.x = moveVector.x;
        direction.z = moveVector.y;
        if (context.performed) held = true;
        if (context.canceled) held = false;
    }
}
