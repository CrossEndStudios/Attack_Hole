using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    IEnumerator loadLevel() {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Attack");
    }
}
