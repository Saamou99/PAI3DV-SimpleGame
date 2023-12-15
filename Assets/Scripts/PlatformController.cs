using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust this value to set the movement speed
    private int direction = 1; // 1 for right, -1 for left
    public float leftBoundary = -5f; // Adjust this value to set the left boundary
    public float rightBoundary = 5f; // Adjust this value to set the right boundary

    void Update()
    {
        // Move the platform
        MovePlatform();
    }

    // Function to move the platform horizontally within specified boundaries
    void MovePlatform()
    {
        // Calculate the new position based on the direction and speed
        float horizontalMovement = direction * movementSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(horizontalMovement, 0f, 0f);

        // Check if the platform is within the boundaries
        if (newPosition.x < leftBoundary || newPosition.x > rightBoundary)
        {
            // Change direction when reaching a boundary
            direction *= -1;
        }

        // Update the platform's position
        transform.position = newPosition;
    }
}