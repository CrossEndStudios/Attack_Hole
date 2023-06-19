using Cinemachine;
using DxCoder;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public AmmoButtons[] ammoButton;
    public GameObject GameWin,GameOver;
    public TextMeshProUGUI coinText;
    public Text RewardCoin;
    public Button RewardButton;
    public CinemachineVirtualCameraBase camera1;
    public CinemachineVirtualCameraBase camera2;
    [HideInInspector]
    public bool isGameOver = false;
    int healthPoints;
    int PreviousCoinsAmount=0;
    public GameObject Nuke;
    // Start is called before the first frame update
    void Start()
    {
        // Set the first virtual camera as the active camera
        camera1.Priority = 10;
        camera2.Priority = 0;
        GameWin.SetActive(false);
        ButtonActivate();
        coinText.text = ""+ GameDataManager.instance.GetCoins();
        Nuke.SetActive(false);
        RewardButton.interactable = false;
        healthPoints = AmmoManager.instance.GetTotalAmmoCount();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void ButtonActivate() {
        for (int i = 0; i < ammoButton.Length; i++)
        {
           int ammoName =  AmmoManager.instance.GetAmmo(ammoButton[i].weaponName);
            if (ammoName != 0)
            {
                ammoButton[i].AmmoButton.SetActive(true);
                ammoButton[i].countText.text = "" + ammoName;
            }
        }
    }

    public void ShowWinUI() {
        isGameOver = true;
        Nuke.SetActive(true);
        int newLevel = GameDataManager.instance.GetCurrentLevel();
        GameDataManager.instance.SetCurrentLevel(newLevel+1);
        
        StartCoroutine(UpdateCoinsAmount());
        AmmoManager.instance.ResetPowerUpCounts();
        // GameDataManager.instance.DestroGame();
        // SceneManager.LoadScene("Game");
       // SoundManager.Instance.PlaySound(SoundManager.Instance.GameWinMusic);
        GameWin.SetActive(true);
        //Adcontrol.instance.ShowAd();
    }

    public void ShowGameOver()
    {
        isGameOver = true;
     
        AmmoManager.instance.ResetPowerUpCounts();
        // GameDataManager.instance.DestroGame();
        // SceneManager.LoadScene("Game");
        StartCoroutine(GameOverDelay());
    }

    public void UpdateText(int name) {
        int ammoName = AmmoManager.instance.GetAmmo(ammoButton[name].weaponName);
        ammoButton[name].countText.text = "" + ammoName;
    }

    public void NextLevel() {
        SceneManager.LoadScene("Game");

    }

    IEnumerator GameOverDelay() {
        //SoundManager.Instance.PlaySound(SoundManager.Instance.GameOverMusic);

        yield return new   WaitForSeconds(1.5f);

        camera2.Priority = 10;
        camera1.Priority = 0;
        GameOver.SetActive(true);
       // Adcontrol.instance.ShowAd();

    }

    public void GotoMenu() {
        SceneManager.LoadScene("Shop");
    }
    private IEnumerator UpdateCoinsAmount()
    {
        yield return new WaitForSeconds(2f);
        // Animation for increasing and decreasing of coins amount
        const float seconds = 0.5f;
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            RewardCoin.text = Mathf.Floor(Mathf.Lerp(PreviousCoinsAmount, healthPoints, (elapsedTime / seconds))).ToString();
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        PreviousCoinsAmount = healthPoints;
        RewardCoin.text = healthPoints.ToString();
        GameDataManager.instance.AddCoins(healthPoints);
      //  PowerUpManager.CheckPowerUps();
    }
}
[System.Serializable]
public class AmmoButtons
{
    public GameObject AmmoButton;
    public string weaponName;
    public TextMeshProUGUI countText;
    public int damage;
}
