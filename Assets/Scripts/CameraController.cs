using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;
    public Camera thirdCamera;

    private AudioListener firstListener;
    private AudioListener secondListener;
    private AudioListener thirdListener;

    private Camera activeCamera;
    private AudioListener activeListener;

    // Start is called before the first frame update
    void Start()
    {
        // Get AudioListeners from cameras
        firstListener = firstCamera.GetComponent<AudioListener>();
        secondListener = secondCamera.GetComponent<AudioListener>();
        thirdListener = thirdCamera.GetComponent<AudioListener>();

        // Set the initial active camera and listener
        activeCamera = firstCamera;
        activeListener = firstListener;

        // Set the initial states
        SetActiveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Shift key is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            // Toggle the active camera and listener
            ToggleActiveCamera();
        }
    }

    void ToggleActiveCamera()
    {
        // Toggle the active camera and listener
        if (activeCamera == firstCamera)
        {
            activeCamera = secondCamera;
            activeListener = secondListener;
        }
        else if (activeCamera == secondCamera)
        {
            activeCamera = thirdCamera;
            activeListener = thirdListener;
        }
        else
        {
            activeCamera = firstCamera;
            activeListener = firstListener;
        }

        // Set the active camera and listener
        SetActiveCamera();
    }

    void SetActiveCamera()
    {
        // Disable all cameras and listeners
        firstCamera.enabled = false;
        secondCamera.enabled = false;
        thirdCamera.enabled = false;

        firstListener.enabled = false;
        secondListener.enabled = false;
        thirdListener.enabled = false;

        // Enable the active camera and listener
        activeCamera.enabled = true;
        activeListener.enabled = true;
    }
}