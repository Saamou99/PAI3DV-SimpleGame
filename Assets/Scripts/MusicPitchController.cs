using UnityEngine;

public class MusicPitchController : MonoBehaviour
{
    public float initialPitch = 0.8f;
    public float pitchIncreaseAmount = 0.02f;
    public float maxPitch = 1.1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
            enabled = false; // Disable the script if no AudioSource is found.
        }

        audioSource.pitch = initialPitch;
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