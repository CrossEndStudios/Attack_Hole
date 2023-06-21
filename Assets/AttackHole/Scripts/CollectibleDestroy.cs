using DxCoder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectibleDestroy : MonoBehaviour
{
     string powerUpName;
    [SerializeField]private Image image;
    [SerializeField] private GameObject Player;
    float circleCapacity;
    // The reference to the AmmoManager object
    AmmoManager powerUpManager;
    // Start is called before the first frame update
    void Start()
    {
        powerUpManager = GameObject.FindObjectOfType<AmmoManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible)) {
            GameDataManager.instance.AddCoins(5);
            powerUpName = other.gameObject.GetComponent<Collectible>().WeaponName;
            powerUpManager.AddAmmo(powerUpName);
            ProgressBarCirlce(30);
            // SoundManager.Instance.PlaySound(SoundManager.Instance.Collect);

            Collectible c = other.gameObject.GetComponent<Collectible>();
            c.PlayAUDIO();

            Destroy(other.gameObject,1);
        }
    }

    public void ProgressBarCirlce(int number) {
        circleCapacity = 1f / number;
        image.fillAmount += circleCapacity;
        if(image.fillAmount.Equals(1f)) {
            Player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            image.fillAmount = 0f;
        }
    }
}
