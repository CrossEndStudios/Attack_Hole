using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    // The time between rewards in hours:minutes:seconds format
    private string rewardInterval = "24:00:00"; // default to 24 hours

    // The UI text element displaying the timer
    public Text timerText;

    // The time of the last reward
    private DateTime lastRewardTime;

    // The time of the next reward
    private DateTime nextRewardTime;

    private void Start()
    {
      //  rewardInterval = AppInfo.Instance.DailyRewardInterval;
        // Load the last reward time from the player preferences
        string lastRewardTimeString = PlayerPrefs.GetString("lastRewardTime", "");
        if (lastRewardTimeString != "")
        {
            lastRewardTime = DateTime.Parse(lastRewardTimeString);
        }
        else
        {
            lastRewardTime = DateTime.MinValue;
        }

        // Calculate the next reward time
        nextRewardTime = CalculateNextRewardTime();

        // Update the UI timer text
        UpdateTimerText();
    }

    private void Update()
    {
        // Check if it's time for the next reward
        if (DateTime.Now >= nextRewardTime)
        {
            // Give the reward and update the last reward time
            GiveReward();
            lastRewardTime = DateTime.Now;
            nextRewardTime = CalculateNextRewardTime();
            PlayerPrefs.SetString("lastRewardTime", lastRewardTime.ToString());
            UpdateTimerText();
        }
        else
        {
            // Update the UI timer text
            UpdateTimerText();
        }
    }

    private void GiveReward()
    {
        //GameManager.instance.AddCoins(200);
        // TODO: Give the reward to the player
    }

    private DateTime CalculateNextRewardTime()
    {
        // Parse the reward interval string into hours, minutes, and seconds
        string[] parts = rewardInterval.Split(':');
        int hours = int.Parse(parts[0]);
        int minutes = int.Parse(parts[1]);
        int seconds = int.Parse(parts[2]);

        // Calculate the next reward time based on the current time and the reward interval
        DateTime nextRewardTime = lastRewardTime.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);

        return nextRewardTime;
    }

    private void UpdateTimerText()
    {
        // Calculate the time remaining until the next reward
        TimeSpan remainingTime = nextRewardTime - DateTime.Now;

        // Update the UI timer text
        if (remainingTime.TotalSeconds <= 0)
        {
            timerText.text = "Collect your daily reward!";
        }
        else
        {
            timerText.text = "Next reward in: " + remainingTime.ToString(@"hh\:mm\:ss");
        }
    }
}
