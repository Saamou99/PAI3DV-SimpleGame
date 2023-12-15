using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    private AudioListener[] audioListeners;

    private Camera activeCamera;
    private AudioListener activeListener;

    public float switchInterval = 10f; // Time interval between camera switches
    private float autoSwitchTimer = 0f;

    public float manualSwitchCooldown = 1f; // Cooldown after a manual switch
    private float manualSwitchCooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (cameras.Length == 0)
        {
            Debug.LogError("No cameras assigned to the script.");
            enabled = false; // Disable the script if no cameras are assigned.
            return;
        }

        // Get AudioListeners from cameras
        audioListeners = new AudioListener[cameras.Length];
        for (int i = 0; i < cameras.Length; i++)
        {
            audioListeners[i] = cameras[i].GetComponent<AudioListener>();
        }

        // Set the initial active camera and listener
        int randomIndex = Random.Range(0, cameras.Length);
        activeCamera = cameras[randomIndex];
        activeListener = audioListeners[randomIndex];

        // Set the initial states
        SetActiveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Shift key is pressed
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.C))
        {
            // Check if the manual switch is allowed (cooldown is over)
            if (manualSwitchCooldownTimer <= 0f)
            {
                // Toggle the active camera and listener
                ToggleActiveCamera();

                // Start the manual switch cooldown timer
                manualSwitchCooldownTimer = manualSwitchCooldown;
            }
        }

        // Automatic camera switching
        autoSwitchTimer += Time.deltaTime;
        manualSwitchCooldownTimer -= Time.deltaTime;

        if (autoSwitchTimer >= switchInterval)
        {
            // Reset the timer
            autoSwitchTimer = 0f;

            // Randomly select the next active camera
            int randomIndex = Random.Range(0, cameras.Length);
            activeCamera = cameras[randomIndex];
            activeListener = audioListeners[randomIndex];

            // Set the active camera and listener
            SetActiveCamera();

            // Start the manual switch cooldown timer after an automatic switch
            manualSwitchCooldownTimer = manualSwitchCooldown;
        }
    }

    void ToggleActiveCamera()
    {
        // Toggle the active camera and listener
        int currentIndex = System.Array.IndexOf(cameras, activeCamera);
        int nextIndex = (currentIndex + 1) % cameras.Length;

        activeCamera = cameras[nextIndex];
        activeListener = audioListeners[nextIndex];

        // Set the active camera and listener
        SetActiveCamera();
    }

    void SetActiveCamera()
    {
        // Disable all cameras and listeners
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
            audioListeners[i].enabled = false;
        }

        // Enable the active camera and listener
        activeCamera.enabled = true;
        activeListener.enabled = true;
    }
}