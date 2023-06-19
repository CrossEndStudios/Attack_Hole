using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DxCoder;

public class MenuManager : MonoBehaviour
{
    public GameInfo gameInfo;
    public GameObject settingsPanel;
    public Slider soundSlider;
    public AudioSource musicSource;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI LevelText, LevelNum;

    void Start()
    {
        // Set up event listeners for the sliders
        soundSlider.onValueChanged.AddListener(delegate { OnSoundVolumeChanged(); });

        // Load the saved sound and music volume settings
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
        
        // Play the background music
        musicSource.Play();

        // Load and display the current level
        //  int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        GameDataManager.instance.LoadGameData();
        LevelText.text = "Level " + GameDataManager.instance.GetCurrentLevel();
        LevelNum.text = "" + (GameDataManager.instance.GetCurrentLevel()+1);
        coinText.text = "" + GameDataManager.instance.GetCoins();
    }
  

    public void OnRateButtonClicked()
    {
        buttonClick();
        // Open the link to the app store to rate the game
        Application.OpenURL(gameInfo.rateUsUrl);
    }

    public void OnMoreGamesButtonClicked()
    {
        buttonClick();

        // Open the link to the developer's other games
        Application.OpenURL(gameInfo.moreGamesUrl);
    }

    public void OnSupportButtonClicked()
    {
        buttonClick();

        // Open the link to the developer's other games
        Application.OpenURL(gameInfo.moreGamesUrl);
    }
    public void OnAboutButtonClicked()
    {
        buttonClick();

        // Open the link to the developer's other games
        Application.OpenURL(gameInfo.moreGamesUrl);
    }

    public void OnPrivacyButtonClicked()
    {
        buttonClick();

        // Open the link to the game's privacy policy
        Application.OpenURL(gameInfo.PrivacyPolicy);
    }

    public void OnSettingsButtonClicked()
    {
        buttonClick();

        // Open the settings panel
        settingsPanel.SetActive(true);
    }

    public void OnSoundVolumeChanged()
    {
        // Update the sound volume setting and the audio listener's volume
        float volume = soundSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", volume);
        AudioListener.volume = volume;
    }

    public void OnMusicVolumeChanged()
    {
        // Update the music volume setting and the music source's volume
     //   float volume = musicSlider.value;
       // PlayerPrefs.SetFloat("MusicVolume", volume);
       // musicSource.volume = volume;
    }

    public void OnShopButtonClicked() {
        buttonClick();

        SceneManager.LoadScene("Shop");
    }

    public void UpdateText() {
        coinText.text = "" + GameDataManager.instance.GetCoins();
    }

    public void buttonClick() {
        //SoundManager.Instance.PlaySound(SoundManager.Instance.button);
    }
}
