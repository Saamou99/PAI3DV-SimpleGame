using System.Collections;
using UnityEngine;

public class UpDownSpin : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float upDownAmplitude = 0.5f;

    void Start()
    {
        StartCoroutine(SpinAndMoveUpDown());
    }

    IEnumerator SpinAndMoveUpDown()
    {
        Vector3 originalPosition = transform.position;

        while (true)
        {
            // Rotate the object around its up axis
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Move the object up and down using a sine wave
            float upDownOffset = Mathf.Sin(Time.time) * upDownAmplitude;
            transform.position = originalPosition + new Vector3(0f, upDownOffset, 0f);

            yield return null;
        }
    }
}