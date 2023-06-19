using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;

public class FortuneWheelManager : MonoBehaviour
{
    private bool _isStarted;
    private float[] _sectorsAngles;
    private float _finalAngle;
    private float _startAngle = 0;
    private float _currentLerpRotationTime;
    public Button TurnButton;
    public GameObject Circle; 			// Rotatable Object with rewards
    public Text CoinsDeltaText;
    public GameObject CoinsDeltaParent;// Pop-up text with wasted or rewarded coins amount
    public TextMeshProUGUI CurrentCoinsText; 		// Pop-up text with wasted or rewarded coins amount
    public int TurnCost = 300;			// How much coins user waste when turn whe wheel
    public int CurrentCoinsAmount;	// Started coins amount. In your project it can be set up from CoinsManager or from PlayerPrefs and so on
    public int PreviousCoinsAmount;		// For wasted coins animation

    public PowerUpManager PowerUpManager;
    private void Start ()
    {
        CurrentCoinsAmount = GameDataManager.instance.GetCoins();
        PreviousCoinsAmount = CurrentCoinsAmount;
        //CurrentCoinsText.text = CurrentCoinsAmount.ToString ();
    }

    public void TurnWheel ()
    {
    	// Player has enough money to turn the wheel
        if (CurrentCoinsAmount >= TurnCost) {
    	    _currentLerpRotationTime = 0f;

            // Fill the necessary angles (for example if you want to have 12 sectors you need to fill the angles with 30 degrees step)
            _sectorsAngles = new float[] { 45, 90, 135, 180, 225, 270, 315, 360 };
            int fullCircles = 5;
    	    float randomFinalAngle = _sectorsAngles [UnityEngine.Random.Range (0, _sectorsAngles.Length)];
    	
    	    // Here we set up how many circles our wheel should rotate before stop
    	    _finalAngle = -(fullCircles * 360 + randomFinalAngle);
    	    _isStarted = true;
    	
    	    PreviousCoinsAmount = CurrentCoinsAmount;
    	
    	    // Decrease money for the turn
    	    CurrentCoinsAmount -= TurnCost;
            GameDataManager.instance.RemoveCoins(TurnCost);
    	
    	    // Show wasted coins
    	    CoinsDeltaText.text = "-" + TurnCost;
    	    CoinsDeltaParent.gameObject.SetActive (true);
    	
    	    // Animate coins
    	    StartCoroutine (HideCoinsDelta ());
    	    StartCoroutine (UpdateCoinsAmount ());
    	}
    }

    private void GiveAwardByAngle ()
    {
    	// Here you can set up rewards for every sector of wheel
    	switch ((int)_startAngle) {
    	case 0:
    	    RewardCoins (1000);
    	    break;
    	case -315:
    	    RewardCoins (2000);
    	    break;
    	case -270:
    	    RewardCoins (500);
    	    break;
    	case -225:
    	    RewardCoins (0);
    	    break;
    	case -180:
    	    RewardCoins (200);
    	    break;
    	case -135:
    	    RewardCoins (2);
    	    break;
    	case -90:
    	    RewardCoins (2000);
    	    break;
    	case -45:
    	    RewardCoins (0);
    	    break;
    	
    	default:
    	    RewardCoins (300);
    	    break;
        }
    }

    void Update ()
    {
        // Make turn button non interactable if user has not enough money for the turn
    	if (_isStarted || CurrentCoinsAmount < TurnCost) {
    	    TurnButton.interactable = false;
    	    TurnButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
    	} else {
    	    TurnButton.interactable = true;
    	    TurnButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
    	}

    	if (!_isStarted)
    	    return;

    	float maxLerpRotationTime = 4f;
    
    	// increment timer once per frame
    	_currentLerpRotationTime += Time.deltaTime;
    	if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle) {
    	    _currentLerpRotationTime = maxLerpRotationTime;
    	    _isStarted = false;
    	    _startAngle = _finalAngle % 360;
    
    	    GiveAwardByAngle ();
    	    StartCoroutine(HideCoinsDelta ());
    	}
    
    	// Calculate current position using linear interpolation
    	float t = _currentLerpRotationTime / maxLerpRotationTime;
    
    	// This formulae allows to speed up at start and speed down at the end of rotation.
    	// Try to change this values to customize the speed
    	t = t * t * t * (t * (6f * t - 15f) + 10f);
    
    	float angle = Mathf.Lerp (_startAngle, _finalAngle, t);
    	Circle.transform.eulerAngles = new Vector3 (0, 0, angle);
    }

    private void RewardCoins (int awardCoins)
    {
        CurrentCoinsAmount += awardCoins;
        CoinsDeltaText.text = "+" + awardCoins;
        CoinsDeltaParent.gameObject.SetActive (true);
        GameDataManager.instance.AddCoins(awardCoins);

        StartCoroutine(UpdateCoinsAmount ());
    }

    private IEnumerator HideCoinsDelta ()
    {
        yield return new WaitForSeconds (1f);
	CoinsDeltaParent.gameObject.SetActive (false);
    }

    private IEnumerator UpdateCoinsAmount ()
    {
    	// Animation for increasing and decreasing of coins amount
    	const float seconds = 0.5f;
    	float elapsedTime = 0;
    
    	while (elapsedTime < seconds) {
    	    CurrentCoinsText.text = Mathf.Floor(Mathf.Lerp (PreviousCoinsAmount, CurrentCoinsAmount, (elapsedTime / seconds))).ToString ();
    	    elapsedTime += Time.deltaTime;
    
    	    yield return new WaitForEndOfFrame ();
        }
    
    	PreviousCoinsAmount = CurrentCoinsAmount;
    	CurrentCoinsText.text = CurrentCoinsAmount.ToString ();
        PowerUpManager.CheckPowerUps();
    }
}
