using UnityEngine;

public class MusicPitchController : MonoBehaviour
{
    public float initialPitch = 0.8f; // Initial pitch value for the audio source
    public float pitchIncreaseAmount = 0.02f; // Amount by which the pitch increases
    public float maxPitch = 1.1f; // Maximum allowed pitch value

    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on the GameObject
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
            enabled = false; // Disable the script if no AudioSource is found.
        }

        audioSource.pitch = initialPitch; // Set the initial pitch value
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assuming the trigger is placed at the starting point.
        if (other.CompareTag("OutOfBounds"))
        {
            // Increase the pitch but clamp it to the maximum value.
            audioSource.pitch = Mathf.Min(audioSource.pitch + pitchIncreaseAmount, maxPitch);
        }
    }
}