using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigibody; // Rigidbody component of the player
    [SerializeField] float movementSpeed = 5.0f; // Speed of player movement
    [SerializeField] float jumpForce = 5f; // Force applied when the player jumps
    [SerializeField] Transform startingPoint;  // Assign the starting point in the Unity Editor

    private bool levelCompleted = false; // Flag to track if the level is completed
    private float startTime; // Time when the player starts moving
    private bool canJump = true; // Flag to determine if the player can jump

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>(); // Get the Rigidbody component
        startTime = Time.time; // Record the start time
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelCompleted)
        {
            // Get input for player movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Move the player based on input
            rigibody.linearVelocity = new Vector3(horizontalInput * movementSpeed, rigibody.linearVelocity.y, verticalInput * movementSpeed);

            // Check for jump input and allow jumping
            if (Input.GetButtonDown("Jump") && canJump)
            {
                rigibody.linearVelocity = new Vector3(rigibody.linearVelocity.x, jumpForce, rigibody.linearVelocity.z);
                canJump = false; // Prevent jumping until the player collides with the ground again
            }
        }
    }

    // Called when a Collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (!levelCompleted && other.CompareTag("FinishLine"))
        {
            levelCompleted = true; // Set level completion flag
            CompleteLevel(); // Call the function to complete the level
        }
        else if (other.CompareTag("OutOfBounds"))
        {
            // Player has fallen out of bounds, reset to the starting point
            ResetToStartingPoint();
        }
    }

    // Called when the player collides with another object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Player has collided with the ground, allowing them to jump again
            canJump = true;
        }
    }

    // Function to reset the player to the starting point
    void ResetToStartingPoint()
    {
        transform.position = startingPoint.position; // Set the player's position to the starting point
        rigibody.linearVelocity = Vector3.zero; // Zero out the player's velocity
        canJump = true; // Allow jumping again after resetting
    }

    // Function to complete the level
    void CompleteLevel()
    {
        rigibody.linearVelocity = Vector3.zero; // Stop player movement

        // Calculate time taken to complete the level
        float timeTaken = Time.time - startTime;

        // Output time taken to the console (for testing purposes)
        Debug.Log(timeTaken);

        // Load the level completion scene with time information
        SceneManager.LoadScene("LevelCompleteScene", LoadSceneMode.Single);

        // Save the time taken in PlayerPrefs for use in other scenes or scripts
        PlayerPrefs.SetFloat("TimeTaken", timeTaken);
    }
}