using DxCoder;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    [Header("Buttons")]
    [Space]
    [SerializeField] public PowerUpButtons power_scale;
    [SerializeField] private PowerUpButtons power_time;
    [SerializeField] private PowerUpButtons power_speed;


    string lvl_power_scale = "power_scale";
    string lvl_power_time = "power_power";
    string lvl_power_speed = "power_speed";

    [Space]
    [Header("Power Up Amount")]
    [Space]
    public int[] power_scale_amt;
    public int[] power_time_amt;
    public int[] power_speed_amt;

    [Space]
    public GameObject Player;
    public Timer timer;
    int coins;

    public Button SizeButtonReward,TimerButtonReward;
    public ParticleSystem particleSystem;

    public MenuManager menuManager;
    public GameObject popupSize, popuptime;
    int pref_scale, pref_time, pref_speed;
    // Start is called before the first frame update
    void Start()
    {
        
        GameDataManager.instance.LoadGameData();
        pref_scale = PlayerPrefs.GetInt(lvl_power_scale, 0);
        pref_time = PlayerPrefs.GetInt(lvl_power_time, 0);
        pref_speed = PlayerPrefs.GetInt(lvl_power_speed, 0);
        SetSize();
        SetTime();
        SetSpeed();
        CheckPowerUps();
        coins = GameDataManager.instance.GetCoins();
        /*if (Adcontrol.instance.isReawrdLoaded)
        {
            SizeButtonReward.interactable = true;
            TimerButtonReward.interactable = true;
        }
        else {
            SizeButtonReward.interactable = false;
            TimerButtonReward.interactable = false;
        }*/
    }

    public void CheckPowerUps() { 
        int coins = GameDataManager.instance.GetCoins();
        int powerupcoin_scale = power_scale_amt[pref_scale];
        int powerupcoin_time = power_time_amt[pref_time];
        int powerupcoin_speed = power_speed_amt[pref_speed];


        Debug.Log("CHECKING COINS _________________" + coins);
        if (coins > powerupcoin_scale)
        {
            power_scale.button.interactable = true;
            power_scale.Upgrade.SetActive(true);
            power_scale.amount.text = "" + powerupcoin_scale;

        }
        else
        {
            power_scale.button.interactable = false;
            power_scale.Upgrade.SetActive(false);
            power_scale.amount.text = "" + powerupcoin_scale;

        }
        if (coins > powerupcoin_time)
        {
            power_time.button.interactable = true;
            power_time.Upgrade.SetActive(true);
            power_time.amount.text = "" + powerupcoin_time;


        }
        else {
            power_time.button.interactable = false;
            power_time.Upgrade.SetActive(false);
            power_time.amount.text = "" + powerupcoin_time;


        }
        if (coins > powerupcoin_speed)
        {
            power_speed.button.interactable = true;
            power_speed.Upgrade.SetActive(true);
            power_speed.amount.text = "" + powerupcoin_speed;


        }
        else
        {
            power_speed.button.interactable = false;
            power_speed.Upgrade.SetActive(false);
            power_speed.amount.text = "" + powerupcoin_speed;

        }

    }


    public void OnPowerScaleButton() {
        int level = PlayerPrefs.GetInt(lvl_power_scale, 0);
        int powerupcoin = power_scale_amt[level];
        GameDataManager.instance.RemoveCoins(powerupcoin);
        PlayerPrefs.SetInt(lvl_power_scale, (level+1));
       // Player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        SetSize();
        particleSystem.Play();
        CheckPowerUps();
        menuManager.UpdateText();
        PowerUpSound();
        Debug.Log("Power Size button clicked");

    }

    public void OnPowerTimeButton() {
        int level = PlayerPrefs.GetInt(lvl_power_time, 0);
        int powerupcoin = power_time_amt[level];
        GameDataManager.instance.RemoveCoins(powerupcoin);
        PlayerPrefs.SetInt(lvl_power_time, (level+1));
        //timer.totalTime += 3;
        //timer.UpdateTimerText(timer.totalTime);
        SetTime();
        particleSystem.Play();

        CheckPowerUps();
        menuManager.UpdateText();
        PowerUpSound();
        Debug.Log("Power Gain button clicked");
    }

    public void ONPowerSpeedButton() {
        int level = PlayerPrefs.GetInt(lvl_power_speed, 0);
        int powerupcoin = power_speed_amt[level];
        GameDataManager.instance.RemoveCoins(powerupcoin);
        PlayerPrefs.SetInt(lvl_power_speed, (level+1));
        //Player.GetComponent<PlayerControl>().movespeed -= 0.5F;
        SetSpeed();
        particleSystem.Play();

        CheckPowerUps();
        menuManager.UpdateText();
        PowerUpSound();
        Debug.Log("Power Speed button clicked");

    }


    public void SetSize() {
        pref_scale = PlayerPrefs.GetInt(lvl_power_scale, 0);
        power_scale.PowerUpLvl.text = "Lvl. " + pref_scale;
        Player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f)*pref_scale;

    }
    public void SetTime() {
        pref_time = PlayerPrefs.GetInt(lvl_power_time, 0);
        power_time.PowerUpLvl.text = "Lvl. " + pref_time;
        timer.totalTime += 3 * pref_time;
       timer.UpdateTimerText(timer.totalTime);

    }
    public void SetSpeed() {
        pref_speed = PlayerPrefs.GetInt(lvl_power_speed,0);
        power_speed.PowerUpLvl.text = "Lvl. " + pref_speed;
        Player.GetComponent<PlayerControl>().movespeed -= 0.2f*pref_speed;
    }

    public void OnRewardSizeClicked() {
        PowerUpSound();

        //Adcontrol.instance.ShowRewardedAd();
    }
    public void OnRewardTimeClicked() {
        PowerUpSound();

        //Adcontrol.instance.ShowRewardedAd();

    }

    public void RewardSize() {
        particleSystem.Play();
      //  popupSize.SetActive(true);
        Player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        PowerUpSound();

    }

    public void RewardTime() {
        particleSystem.Play();
     //   popuptime.SetActive(true);
        timer.totalTime += 5;
        Debug.LogError("Rewarded Time");
        PowerUpSound();
    }

    public void PowerUpSound() {
       // SoundManager.Instance.PlaySound(SoundManager.Instance.PowerUp);
    }
}

[System.Serializable]
public class PowerUpButtons {

    public Button button;
    public GameObject Upgrade;
    public TextMeshProUGUI amount;
    public TextMeshProUGUI PowerUpLvl;

}
