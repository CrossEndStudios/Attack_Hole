using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMesh timerTextMesh;
    private float timer = 0f;
    public float totalTime = 60f; // Default total time is 60 seconds
    private bool isTimerRunning = false;
    bool isTimerStarted;
    private void Start()
    {
     //   StartTimer();
        isTimerStarted = false;
    }
    void StartTimer()
    {
       
        timer = 0f;
        isTimerRunning = true;
    }

    void StopTimer()
    {
        isTimerRunning = false;
    }

    void SetTotalTime(float time)
    {
        totalTime = time;
    }

    public void UpdateTimerText(float timeLeft)
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f); // Calculate minutes by dividing by 60
        int seconds = Mathf.FloorToInt(timeLeft % 60f); // Calculate seconds by taking remainder of 60

        timerTextMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format text to show mm:ss format
    }

    void Update()
    {
        if (GameManager.instance.iSGameStarted && !isTimerStarted) {
            StartTimer();
            isTimerStarted = true;
        }

        if (isTimerRunning)
        {
            totalTime -= Time.deltaTime;
            if (totalTime <= 0f)
            {
                totalTime = 0f;
                StopTimer();
                GameManager.instance.GameEnd();

            }
            UpdateTimerText(totalTime);
        }
    }


}
