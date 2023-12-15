using UnityEngine;

public class QuitApp : MonoBehaviour
{
    // Function to quit the application
    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the Unity Editor
#else
            Application.Quit(); // Quit the application when not in the Unity Editor
#endif
    }
}