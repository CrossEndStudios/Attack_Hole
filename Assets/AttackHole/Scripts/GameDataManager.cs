using UnityEngine;
using TMPro;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    private int coins;
    private int character;
    private int currentLevel;
    private int sizeUp;
    private int powerUp;
    private int speedUp;
   // public TextMeshProUGUI coinText;

    private string coins_key = "Coins";
    private string char_key = "CurrentCharacterIndex";
    private string currentlevel_key= "CurrentLevel";
    private string sizeup_key = "Size";
    private string powerup_key= "Power";
    private string speedup_key = "Speed";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadGameData();
    }


    //-------------------------ADD----------------------------
    public void AddCoins(int amount)
    {
        coins += amount;
        SaveGameData();
        UpdateGameUI();
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        SaveGameData();
        UpdateGameUI();
    }

    public void AddChar(int CurrentCharacterIndex)
    {
        character = CurrentCharacterIndex;
        SaveGameData();
        UpdateGameUI();

    }

    public void AddSizeUp()
    {
        sizeUp++;
        SaveGameData();
        UpdateGameUI();
    }
    public void AddSpeedUp()
    {
        speedUp++;
        SaveGameData();
        UpdateGameUI();

    }
    public void AddPowerUp()
    {
        powerUp++;
        SaveGameData();
        UpdateGameUI();
    }
    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
        SaveGameData();
        UpdateGameUI();
    }

    //-------------------------------------GET--------------------
    public int GetCoins()
    {
        return coins;
    }

    public int GetChar()
    {
        return character;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }



    public void SaveGameData()
    {
        PlayerPrefs.SetInt(coins_key, coins);
        PlayerPrefs.SetInt(char_key, character);
        PlayerPrefs.SetInt(currentlevel_key, currentLevel);
        PlayerPrefs.SetInt(sizeup_key, sizeUp);
        PlayerPrefs.SetInt(speedup_key, speedUp);
        PlayerPrefs.SetInt(powerup_key, powerUp);
    }

    public void LoadGameData()
    {
        coins = PlayerPrefs.GetInt(coins_key, 0);
        character = PlayerPrefs.GetInt(char_key, 0);
        currentLevel = PlayerPrefs.GetInt(currentlevel_key, 0);
        sizeUp =  PlayerPrefs.GetInt(sizeup_key, 1);
        speedUp = PlayerPrefs.GetInt(speedup_key, 1);
        powerUp = PlayerPrefs.GetInt(powerup_key, 1);
    }

    public void UpdateGameUI() {
       // float coinCountFloat = GetCoins() / 1000f; // Convert coin count to float and divide by 1000
        //coinText.text = coinCountFloat.ToString("0.##") + "k"; // Format float to show 2 decimal places and add "k"
        
    }



    public void SetBossHealth(float Health)
    {
        PlayerPrefs.SetFloat("BossHealth", Health);
        PlayerPrefs.Save();
    }

    public float GetBossHealth()
    {
        float bossHealth = PlayerPrefs.GetFloat("BossHealth", 0);
        return bossHealth;
    }

    public void DestroGame() { 
    Destroy(gameObject);
    }
}
