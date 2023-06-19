using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    [SerializeField]
    int WaitSec;
    //[SerializeField]



    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;

        StartCoroutine(LoadGame());
    }
    IEnumerator LoadGame() {
        yield return new WaitForSeconds(WaitSec);
        SceneManager.LoadScene("Game");
    }
}
