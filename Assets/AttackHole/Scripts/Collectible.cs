using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    Rigidbody rb;
    // The name of the power-up
    public string WeaponName;
    public int damage;


    public AudioSource CollectedAudio;


    [SerializeField] public bool isFalling;

    bool audioPlayed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isFalling) {
           
                rb.AddForce(Vector3.down * rb.mass * Physics.gravity.magnitude * (3 - 1.0f), ForceMode.Force);
           
            

        }

    }
    public void PlayAUDIO()
    {
        if (audioPlayed == false)
        {
            CollectedAudio.Play();
            audioPlayed = true;
        }
    }
}
