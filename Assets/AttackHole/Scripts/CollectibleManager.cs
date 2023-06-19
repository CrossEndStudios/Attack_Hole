using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CollectibleManager : MonoBehaviour
{
    public GameObject[] collectibles;
    public Text[] collectibleTexts;
    public Text summaryText;

    private Dictionary<string, int> collectedItems = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the collected items dictionary with all collectibles
        foreach (GameObject collectible in collectibles)
        {
            collectedItems.Add(collectible.name, 0);
            collectible.SetActive(true);
        }

        // Reset the text for each collectible
        foreach (Text text in collectibleTexts)
        {
            text.text = text.name + ": 0";
        }

        // Load the collected items from PlayerPrefs and update the UI
        LoadCollectedItems();
        UpdateUI();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a collectible
        GameObject collidedObject = other.gameObject;
        if (Array.Exists(collectibles, collectible => collectible == collidedObject))
        {
            // Increment the count for the collected item
            string itemName = collidedObject.name;
            collectedItems[itemName]++;

            // Update the corresponding text object
            Text textToUpdate = GetTextForItem(itemName);
            if (textToUpdate != null)
            {
                textToUpdate.text = itemName + ": " + collectedItems[itemName];
            }

            // Disable the collided object
            collidedObject.SetActive(false);
        }
    }

    // Get the corresponding text object for a given item name
    private Text GetTextForItem(string itemName)
    {
        foreach (Text textObject in collectibleTexts)
        {
            if (textObject.name == itemName)
            {
                return textObject;
            }
        }
        return null;
    }

    // Save the collected items to PlayerPrefs
    public void SaveCollectedItems()
    {
        foreach (KeyValuePair<string, int> item in collectedItems)
        {
            string key = item.Key;
            int value = item.Value;
            PlayerPrefs.SetInt(key, value);
        }
        PlayerPrefs.Save();
    }

    // Load the collected items from PlayerPrefs
    private void LoadCollectedItems()
    {
        foreach (GameObject collectible in collectibles)
        {
            string key = collectible.name;
            int value = PlayerPrefs.GetInt(key, 0);
            collectedItems[key] = value;
        }
    }

    // Update the UI with the collected item counts and summary
    private void UpdateUI()
    {
        // Update the text for each collectible
        foreach (Text text in collectibleTexts)
        {
            string key = text.name;
            text.text = key + ": " + collectedItems[key];
        }

        // Update the summary text with the total number of collected items
        int totalItems = 0;
        foreach (KeyValuePair<string, int> item in collectedItems)
        {
            totalItems += item.Value;
        }
        summaryText.text = "Total collected items: " + totalItems;
    }
}
