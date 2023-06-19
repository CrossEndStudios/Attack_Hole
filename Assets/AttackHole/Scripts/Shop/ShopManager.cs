using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DxCoder;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public Character[] characters; // An array of all the available characters
    public GameObject characterButtonPrefab; // The prefab for the character selection button
    public Transform characterButtonParent; // The parent object for the character selection buttons
    public TextMeshProUGUI coinText; // The text object displaying the number of coins the player has
    public int startingCoins = 0; // The number of coins the player starts with
    private CharacterButton selectedButton;
    public int coins; // The current number of coins the player has
    private const string SELECTED_CHARACTER_KEY = "selectedCharacter";
    public GameObject[] gameObjects;
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = "" + coins.ToString();

        // Create a button for each available character
        for (int i = 0; i < characters.Length; i++)
        {
            bool isUnlocked = PlayerPrefs.GetInt(characters[i].name + "_unlocked", 0) == 1;
            characters[i].isUnlocked = isUnlocked;
            GameObject button = Instantiate(characterButtonPrefab, characterButtonParent);
            button.GetComponent<CharacterButton>().InitButton(characters[i], this);
            characters[i].gameObject = gameObjects[i];
        }

        // Load the selected character from preferences and highlight the corresponding button
        string selectedCharacterName = PlayerPrefs.GetString(SELECTED_CHARACTER_KEY);

        if (!string.IsNullOrEmpty(selectedCharacterName))
        {
            Character selectedCharacter = characters.FirstOrDefault(c => c.name == selectedCharacterName);
            if (selectedCharacter != null)
            {
                SelectCharacter(selectedCharacter);
            }
        }
        else {
            Character selectedCharacter = characters.FirstOrDefault(c => c.name == "Rabbit");
            if (selectedCharacter != null)
            {
                SelectCharacter(selectedCharacter);
            }
        }

    }



    // Called when a character button is clicked
    public void SelectCharacter(Character character)
    {
        if (!character.isUnlocked)
        {
            if (coins >= character.unlockCost)
            {
                if(SoundManager.Instance)
                //SoundManager.Instance.PlaySound(SoundManager.Instance.CharacterUnlock);

                coins -= character.unlockCost;
                character.isUnlocked = true;
                coinText.text = "" + coins.ToString();
                PlayerPrefs.SetString(SELECTED_CHARACTER_KEY, character.name);
                PlayerPrefs.SetInt(character.name + "_unlocked", 1);
                PlayerPrefs.SetInt("Coins", coins);
                PlayerPrefs.Save();
                // Unhighlight the previously selected button (if there was one)
                if (selectedButton != null)
                {
                    selectedButton.SetHighlight(false);
                    selectedButton.costText.text = "Unlocked";
                   // selectedButton.outline.enabled = false;
                }

                // Find the button corresponding to the selected character
                CharacterButton button = characterButtonParent.GetComponentsInChildren<CharacterButton>().FirstOrDefault(b => b.character == character);
                button.UpdateButtonState();
                // Highlight the selected button
                if (button != null)
                {
                    selectedButton = button;
                    selectedButton.SetHighlight(true);
                    selectedButton.costText.text = "Selected";
                   // selectedButton.outline.enabled = true;
                }
                // Activate the corresponding GameObject
                if (character.gameObject != null)
                {
                    for (int i = 0; i < gameObjects.Length; i++)
                    {
                        if (gameObjects[i] != null && gameObjects[i] != character.gameObject)
                        {
                            gameObjects[i].SetActive(false);
                        }
                    }
                    character.gameObject.SetActive(true);
                }
            }
            else {
                //SoundManager.Instance.PlaySound(SoundManager.Instance.CharacterLock);

            }
        }
        else {
            if(SoundManager.Instance)
            //SoundManager.Instance.PlaySound(SoundManager.Instance.button);

            PlayerPrefs.SetString(SELECTED_CHARACTER_KEY, character.name);
            // Unhighlight the previously selected button (if there was one)
            if (selectedButton != null)
            {
                selectedButton.SetHighlight(false);
                selectedButton.costText.text = "Unlocked";
               // selectedButton.outline.enabled = false;

            }

            // Find the button corresponding to the selected character
            CharacterButton button = characterButtonParent
                .GetComponentsInChildren<CharacterButton>().FirstOrDefault(b => b.character == character);
            button.UpdateButtonState();
            // Highlight the selected button
            if (button != null)
            {
                selectedButton = button;
                selectedButton.SetHighlight(true);
                selectedButton.costText.text = "Selected";
             //   selectedButton.outline.enabled = true;
            }
            // Activate the corresponding GameObject
            if (character.gameObject != null)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    if (gameObjects[i] != null && gameObjects[i] != character.gameObject)
                    {
                        gameObjects[i].SetActive(false);
                    }
                }
                character.gameObject.SetActive(true);
            }
        }
    }

    // Called to add coins to the player's total
    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = "" + coins.ToString();
    }

    public void GoToHome() {
        SceneManager.LoadScene("Game");
    }

}

[System.Serializable]
public class Character
{
    public string name; // The name of the character
    public Sprite icon; // The icon for the character
    public int unlockCost; // The cost to unlock the character
    public bool isUnlocked; // Whether or not the character is unlocked
    public GameObject gameObject;

    public Character(string name, Sprite icon, int unlockCost)
    {
        this.name = name;
        this.icon = icon;
        this.unlockCost = unlockCost;
        this.isUnlocked = false;
    }
}


