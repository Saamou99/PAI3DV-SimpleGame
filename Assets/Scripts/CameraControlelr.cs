using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 1.0f;
    public float movementSpeed = 1.0f;
    public float accelerationRate = 0.1f;

    private Vector3 originalPosition;
    private float originalOrthographicSize;
    private float startTime;

    private void Start()
    {
        originalPosition = transform.position;
        originalOrthographicSize = Camera.main.orthographicSize;
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;

        // Zoom in and out
        Camera.main.orthographicSize = originalOrthographicSize + Mathf.Sin(elapsedTime * zoomSpeed) * 2.0f;

        // Continuous movement
        float horizontalMovement = Mathf.Sin(elapsedTime * movementSpeed);
        float verticalMovement = Mathf.Cos(elapsedTime * movementSpeed);

        transform.position = originalPosition + new Vector3(horizontalMovement, verticalMovement, 0);

        // Accelerate movement
        movementSpeed += accelerationRate;
    }
}
