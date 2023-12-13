using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ballPrefab;  // Reference to the ball prefab
    public float respawnTime = 5f;
    public Transform[] spawnPoints; // Array of spawn points

    private GameObject currentBall;

    void Start()
    {
        StartCoroutine(RespawnBallRoutine());
    }

    IEnumerator RespawnBallRoutine()
    {
        while (true)
        {
            // Wait for the specified respawn time
            yield return new WaitForSeconds(respawnTime);

            // If there is already an active ball, do nothing
            if (currentBall != null)
                continue;

            // Randomly choose a spawn point from the array
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate a new ball at the chosen spawn point
            currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

            // Add Rigidbody component to the instantiated ball
            Rigidbody ballRb = currentBall.GetComponent<Rigidbody>();
            if (ballRb == null)
            {
                ballRb = currentBall.AddComponent<Rigidbody>();
            }
        }
    }
}