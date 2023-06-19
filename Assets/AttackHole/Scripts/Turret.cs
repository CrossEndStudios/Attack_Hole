using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] projectilePrefab;
    public Transform turretTrans;
    public float projectileSpeed = 10f;
    public float gravity = 9.8f;
    public float maxHeight = 2f;
    private bool isFiring = false;
    private float timeSinceLastFire = 0.0f;
    public float fireSpeed = 1.0f;
    private int currentProjectileIndex = 0;
    [SerializeField] private BossManager bossManager;

    int smallBullet, bigBullet;
    private void Start()
    {
        smallBullet = AmmoManager.instance.GetAmmo("SmallBullet");
        bigBullet = AmmoManager.instance.GetAmmo("BigBullet");

    }
    public void Update()
    {
        if (isFiring)
        {
            timeSinceLastFire += Time.deltaTime;

            if (timeSinceLastFire >= 1.0f / fireSpeed)
            {
                if (AmmoManager.instance.GetAmmo(bossManager.ammoButton[currentProjectileIndex].weaponName) != 0)
                {
                    Fire();
                    AmmoManager.instance.RemovePowerUp(bossManager.ammoButton[currentProjectileIndex].weaponName, 1);
                    bossManager.UpdateText(currentProjectileIndex);
                }
                timeSinceLastFire = 0f;
            }
        }
        
    }
    public void Fire()
    {
        int randomIndex = Random.Range(0, targets.Length);
        GameObject target = targets[randomIndex];
        // Calculate the distance and direction to the target
        Vector3 targetPos = target.transform.position;
        Vector3 turretPos = turretTrans.position;
        Vector3 direction = targetPos - turretPos;
        direction.y = 0;
        float distance = direction.magnitude;

        // Calculate the time to reach max height
        float timeToMaxHeight = Mathf.Sqrt(2f * maxHeight / gravity);

        // Calculate the time to reach the target
        float timeToTarget = Mathf.Sqrt(2f * distance / gravity);

        // Calculate the initial velocity needed to reach the target at the given max height
        Vector3 initialVelocity = direction / timeToTarget + Vector3.up * gravity * timeToMaxHeight;

        // Instantiate the projectile and set its initial velocity
        GameObject projectile = Instantiate(projectilePrefab[currentProjectileIndex], turretPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = initialVelocity;
    }

    public void Down()
    {
        
        isFiring = true;
    }

    public void Up()
    {
       

        isFiring = false;
        timeSinceLastFire = 0.0f;
    }
    public void SetCurrentProjectileIndex(int index)
    {
        currentProjectileIndex = index;
    }
}
