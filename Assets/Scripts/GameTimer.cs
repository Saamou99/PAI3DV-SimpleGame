using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private float endTime;
    private bool isTiming = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTiming)
        {
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTiming = true;
    }

    public void StopTimer()
    {
        endTime = Time.time;
        isTiming = false;
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            float currentTime = isTiming ? Time.time - startTime : endTime - startTime;
            timerText.text = "Time: " + currentTime.ToString("F2") + "s";
        }
    }
}