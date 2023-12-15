using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // Reference to the UI text displaying the game timer
    private float startTime; // Time when the timer starts
    private float endTime; // Time when the timer stops
    private bool isTiming = false; // Flag to track whether the timer is currently running

    void Start()
    {
        StartTimer(); // Start the timer when the script is first initialized
    }

    void Update()
    {
        if (isTiming)
        {
            UpdateTimerText(); // Update the timer text only if the timer is currently running
        }
    }

    // Function to start the game timer
    public void StartTimer()
    {
        startTime = Time.time; // Record the current time as the start time
        isTiming = true; // Set the flag to indicate that the timer is running
    }

    // Function to stop the game timer
    public void StopTimer()
    {
        endTime = Time.time; // Record the current time as the end time
        isTiming = false; // Set the flag to indicate that the timer has stopped
    }

    // Function to update the timer text on the UI
    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Calculate the elapsed time based on whether the timer is currently running or stopped
            float currentTime = isTiming ? Time.time - startTime : endTime - startTime;
            // Update the UI text to display the elapsed time with two decimal places
            timerText.text = "Time: " + currentTime.ToString("F2") + "s";
        }
    }
}