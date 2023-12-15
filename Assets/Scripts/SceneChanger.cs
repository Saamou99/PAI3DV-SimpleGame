using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string scene; // Name of the scene to load

    // Function to change the scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(scene); // Load the specified scene
    }
}