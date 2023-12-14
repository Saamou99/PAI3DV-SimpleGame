using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigibody;
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform startingPoint;  // Assign the starting point in the Unity Editor

    private bool levelCompleted = false;
    private float startTime;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelCompleted)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rigibody.velocity = new Vector3(horizontalInput * movementSpeed, rigibody.velocity.y, verticalInput * movementSpeed);

            if (Input.GetButtonDown("Jump") && canJump)
            {
                rigibody.velocity = new Vector3(rigibody.velocity.x, jumpForce, rigibody.velocity.z);
                canJump = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!levelCompleted && other.CompareTag("FinishLine"))
        {
            levelCompleted = true;
            CompleteLevel();
        }
        else if (other.CompareTag("OutOfBounds"))
        {
            // Player has fallen out of bounds, reset to the starting point
            ResetToStartingPoint();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Player has collided with the ground, allowing them to jump again
            canJump = true;
        }
    }

    void ResetToStartingPoint()
    {
        // Reset the player to the starting point
        transform.position = startingPoint.position;
        rigibody.velocity = Vector3.zero;
        canJump = true; // Allow jumping again after resetting
    }

    void CompleteLevel()
    {
        // Stop player movement or any other game mechanics
        rigibody.velocity = Vector3.zero;

        // Calculate time taken
        float timeTaken = Time.time - startTime;
        Debug.Log(timeTaken);

        // Load the level completion scene with time information
        SceneManager.LoadScene("LevelCompleteScene", LoadSceneMode.Single);

        
        PlayerPrefs.SetFloat("TimeTaken", timeTaken);
    }
}