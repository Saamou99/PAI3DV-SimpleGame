using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectBalls : MonoBehaviour
{
    public int balls; // Counter for collected balls

    public TextMeshProUGUI ballText; // Reference to the UI text displaying the number of collected balls

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called when another Collider enters the trigger
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Debug.Log("Ball Collected");

            // Increment the ball count
            balls = balls + 1;

            // Deactivate the collected ball
            col.gameObject.SetActive(false);

            // Update the UI text to show the current number of collected balls
            ballText.text = "Collected Balls: " + balls.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic can be added here if needed
    }
}