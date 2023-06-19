using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{

    Vector3 clickedScreenPosition;
    [SerializeField]float screenPositionFollowThreshold;
    public  float movespeed;
    private const string SELECTED_CHARACTER_KEY = "selectedCharacter";
    public GameObject[] characters;
    // Start is called before the first frame update
    void Start()
    {
        string selectedCharacterName = PlayerPrefs.GetString(SELECTED_CHARACTER_KEY,"Rabbit");
        if (selectedCharacterName != null)
        {
            foreach (GameObject go in characters)
            {
                if (go.name == selectedCharacterName)
                {
                    go.SetActive(true);
                    return;
                }
            }
        }
        else
        {
            characters[0].SetActive(true);
        }
    }
   

    void LateUpdate()
    {
        ManageControl();
       
    }



    void ManageControl() {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
           
        }
        else if (Input.GetMouseButton(0)) {
            Vector3 difference = Input.mousePosition - clickedScreenPosition;

            Vector3 direction = difference.normalized;

            float maxScreenDistance = screenPositionFollowThreshold * Screen.height;

            if (difference.magnitude > maxScreenDistance) {

                clickedScreenPosition = Input.mousePosition - direction * maxScreenDistance;
                difference = Input.mousePosition - clickedScreenPosition;
            }

            difference /= Screen.width;
            difference.z = difference.y;
            difference.y = 0;

            Vector3 playerTargetposition = transform.position + difference * movespeed * Time.deltaTime;
            transform.position = playerTargetposition;
        }
    }

    public void OnTriggerStay(Collider other)
    {
       
    }

   
}
