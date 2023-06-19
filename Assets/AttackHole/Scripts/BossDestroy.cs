using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossDestroy : MonoBehaviour
{
    int bossHealth;
    public TextMeshProUGUI _health;
    public BossManager bossManager;
    bool isKilled;
    public Slider slider;
    Animator animator;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isKilled = false;
        bossHealth = ((int)GameDataManager.instance.GetBossHealth());
        slider.maxValue = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
       



        if (bossHealth > 0)
        {
            _health.text = "" + bossHealth;
            slider.value = bossHealth;
        }
        if (bossHealth < 1 && !isKilled) {
            animator.SetTrigger("Hit");
            bossManager.ShowWinUI();
            isKilled = true;
            return;
        }
        if (AmmoManager.instance.GetTotalAmmoCount() == 0)
        {

            StartCoroutine(WaitForAmmo());
        }

    }
    IEnumerator WaitForAmmo() {

        yield return new WaitForSeconds(2f);
        if (!bossManager.isGameOver)
        {
            animator.SetTrigger("Win");
            bossManager.ShowGameOver();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullets")) {
            string projectileName = other.gameObject.GetComponent<Projectile>().projectileName;
            if (!explosion.isPlaying) { 
            explosion.Play();
            }
            switch (projectileName)
            {
                case "small":
                    //AmmoManager.instance.RemovePowerUp("SmallBullet", 1);
                    bossHealth--;
                   // bossManager.UpdateText(0);
                    Debug.Log("Small hit");
                    break;
                case "big":
                    bossHealth = (bossHealth-2);
                   // AmmoManager.instance.RemovePowerUp("BigBullet", 2);
                   // bossManager.UpdateText(1);
                    Debug.Log("Small hit");
                    break;
                case "spike":
                    bossHealth = (bossHealth - 3);
                    // AmmoManager.instance.RemovePowerUp("BigBullet", 2);
                    // bossManager.UpdateText(1);
                    Debug.Log("Small hit");
                    break;
                default:
                    Debug.Log("Don't know what hit us");
                    break;

            }
            Destroy(other.gameObject);
        }
    }
}
