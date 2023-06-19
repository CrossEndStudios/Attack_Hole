using System.Collections.Generic; // Import the Dictionary class
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    // Declare a dictionary to store the number of times each power-up has been collected
    Dictionary<string, int> powerUpCounts = new Dictionary<string, int>();
    public static AmmoManager instance;


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
        ResetPowerUpCounts();
    }

    // Use this method to add a power-up to the dictionary
    public void AddAmmo(string ammoName)
    {
        // If the power-up is not already in the dictionary, add it with a count of 1
        if (!powerUpCounts.ContainsKey(ammoName))
        {
            powerUpCounts.Add(ammoName, 1);
        }
        // If the power-up is already in the dictionary, increment its count
        else
        {
            powerUpCounts[ammoName]++;
        }
        //PlayerPrefs.SetInt(powerUpName, powerUpCounts[powerUpName]);
    }

    // Use this method to get the count for a specific power-up
    public int GetAmmo(string ammoName)
    {
        // If the power-up is in the dictionary, return its count
        if (powerUpCounts.ContainsKey(ammoName))
        {
            return powerUpCounts[ammoName];
        }
        // If the power-up is not in the dictionary, return 0
        else
        {
            return 0;
        }
    }

    public int GetTotalAmmoCount()
    {
        int totalAmmoCount = 0;

        foreach (var kvp in powerUpCounts)
        {
            totalAmmoCount += kvp.Value;
        }

        return totalAmmoCount;
    }


    public void ResetPowerUpCounts()
    {
        // Clear the dictionary
        powerUpCounts.Clear();
    }

    public void RemovePowerUp(string ammoName, int ammo) {
        powerUpCounts[ammoName] = powerUpCounts[ammoName]-ammo;
    }
}
