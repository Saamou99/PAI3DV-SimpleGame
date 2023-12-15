using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private bool isHit = false; // Flag to track if the character has been hit already
    [SerializeField] private float kickForce = 20f; // Adjust the kick force as needed

    // Called when a collision occurs
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cylinder") && !isHit)
        {
            // Get the direction from the ball to the player
            Vector3 kickDirection = transform.position - collision.transform.position;
            kickDirection.Normalize(); // Normalize the vector to maintain the same total force regardless of direction

            // Call the function to kick the character upward and backward
            KickUpAndBackward(kickDirection);
        }
    }

    // Function to apply a force to kick the character both upwards and backward
    void KickUpAndBackward(Vector3 kickDirection)
    {
        // Access the Rigidbody component of the character
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply a force to kick the character upward and backward
            rb.AddForce((Vector3.up + kickDirection) * kickForce, ForceMode.Impulse);
        }
        isHit = true; // Set isHit to true to ensure the character is kicked away only once
    }
}