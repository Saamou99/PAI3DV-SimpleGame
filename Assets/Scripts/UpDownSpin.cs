using System.Collections;
using UnityEngine;

public class UpDownSpin : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed at which the object rotates around its up axis
    public float upDownAmplitude = 0.5f; // Amplitude of the up and down movement

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpinAndMoveUpDown()); // Start the coroutine for spinning and moving up and down
    }

    // Coroutine to spin and move the object up and down
    IEnumerator SpinAndMoveUpDown()
    {
        Vector3 originalPosition = transform.position; // Save the original position of the object

        while (true)
        {
            // Rotate the object around its up axis
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Move the object up and down using a sine wave
            float upDownOffset = Mathf.Sin(Time.time) * upDownAmplitude;
            transform.position = originalPosition + new Vector3(0f, upDownOffset, 0f);

            yield return null; // Wait for the next frame
        }
    }
}