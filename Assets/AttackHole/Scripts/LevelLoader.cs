//The LevelLoader script loads a level based on the current level number stored in GameDataManager.
//If the current level number is less than 50, the level corresponding to that number is loaded. Otherwise, a random level is loaded from the array of level prefabs.
//The Start() method is called when the script is started.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject[] Levels;
    int CurrentLevel;

    void Start()
    {
        CurrentLevel = GameDataManager.instance.GetCurrentLevel();
        if (CurrentLevel < 50)
        {

            Instantiate(Levels[CurrentLevel]);
        }
        else
        {
            int randomLevel = Random.Range(0, 50);
            Instantiate(Levels[randomLevel]);

        }
    }
}
