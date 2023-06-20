using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DxCoder;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Adcontrol ADS;

    private int count, totalAmmo;
    [HideInInspector] public bool iSGameStarted;
    AmmoManager powerUpManager;
    float totalDamage;
    bool isGameEnd;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameEnd = false;
        powerUpManager = GameObject.FindObjectOfType<AmmoManager>();
        iSGameStarted = false;
        //SoundManager.Instance.PlayMusic(SoundManager.Instance.GameMusic);
        totalAmmo = GameObject.FindGameObjectsWithTag("weapons").Length;
        StartCoroutine(CalculateTotalPower());
    }

    // Update is called once per frame
    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("weapons").Length;
        if (count == 0) {
            GameEnd();
        }
    }

    public void Restart() {
       // SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        //SoundManager.Instance.PlaySound(SoundManager.Instance.button);

        SceneManager.LoadScene("Menu");
    }
    public void GameEnd()
    {
        if (!isGameEnd)
        {
            Debug.Log(powerUpManager.GetAmmo("SmallBullet") + " Small Bullet " + powerUpManager.GetAmmo("BigBullet") + " Big Bullet");
            float collectedValue = (powerUpManager.GetAmmo("SmallBullet") * 1) + (powerUpManager.GetAmmo("BigBullet") * 2);
            Debug.Log(collectedValue);
            GameDataManager.instance.SetBossHealth(totalDamage * 0.8f);
            //if (collectedValue < (totalDamage * 0.8))
            //{
            //    Debug.Log("GAMEOVERRRRRRRRRRR");
            //    StartCoroutine(GameEndDelay());
            //}
            //else
            //{
            //    Debug.Log("GameWINNNNNNN");
            //   int newLevel = GameDataManager.instance.GetCurrentLevel();
            //    GameDataManager.instance.SetCurrentLevel(newLevel+1);
                StartCoroutine(GameEndDelay());
            //}
           
            isGameEnd = true;
        }
    }
    
 

    IEnumerator GameEndDelay() {
    
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Attack");
       

    }


  

    public void PlayButton() {
        //SoundManager.Instance.PlaySound(SoundManager.Instance.button);
    }

    IEnumerator CalculateTotalPower() {
        yield return new WaitForSeconds(0.5f);
        totalDamage= 0;
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("weapons");
        foreach (GameObject weapon in weapons)
        {
           totalDamage += weapon.GetComponent<Collectible>().damage;
        }
        Debug.Log("Total Power " + totalDamage);
        Debug.Log(("Boss Health "+totalDamage * 0.8));
    }
}
