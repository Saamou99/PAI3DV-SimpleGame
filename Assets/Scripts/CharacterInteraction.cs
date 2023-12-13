using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private bool isHit = false;
    [SerializeField] private float kickForce = 20f; // Adjust the kick force as needed

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cylinder") && !isHit)
        {
            // Get the direction from the ball to the player
            Vector3 kickDirection = transform.position - collision.transform.position;
            kickDirection.Normalize(); // Normalize the vector to maintain the same total force regardless of direction

            KickUpAndBackward(kickDirection);
        }
    }

    void KickUpAndBackward(Vector3 kickDirection)
    {
        // Apply a force to kick the character both upwards and backward
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce((Vector3.up + kickDirection) * kickForce, ForceMode.Impulse);
        }

        // Optionally, you can add other actions here, such as playing a sound or triggering an animation.
        isHit = true; // Set isHit to true to ensure the character is kicked away only once
    }
}