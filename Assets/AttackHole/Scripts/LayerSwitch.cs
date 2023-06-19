using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitch : MonoBehaviour
{
    [SerializeField]
    private string BeginLayer;
    [SerializeField] private string EndLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = LayerMask.NameToLayer(EndLayer);
        other.gameObject.GetComponent<Collectible>().isFalling = true;
     
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = LayerMask.NameToLayer(BeginLayer);
        other.gameObject.GetComponent<Collectible>().isFalling = false;

    }
}
