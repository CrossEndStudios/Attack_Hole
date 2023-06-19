using UnityEngine;
using UnityEngine.UI;
using DxCoder;
public class PrivacyBanner : MonoBehaviour
{
    public GameObject PolicyDialog;
    // The UI button element for the "I Agree" button
  

    private void Start()
    {
        // Check if the privacy policy has been agreed to before
        bool hasAgreed = PlayerPrefs.GetInt("privacyPolicyAgreed", 0) == 1;

        if (!hasAgreed)
        {
            // Show the privacy policy dialog
            ShowPrivacyPolicyDialog();
        }
        else
        {
            // The privacy policy has already been agreed to, so do nothing
            ClosePrivacyPolicyDialog();
        }
    }

    private void ShowPrivacyPolicyDialog()
    {
        // Show the privacy policy text
       // SoundManager.Instance.PlaySound(SoundManager.Instance.woosh);
        PolicyDialog.SetActive(true);

        // Show the "I Agree" button
        //agreeButton.gameObject.SetActive(true);

        // Pause the game
        //Time.timeScale = 0f;
    }

    private void ClosePrivacyPolicyDialog()
    {
        // Hide the privacy policy text
       // SoundManager.Instance.PlaySound(SoundManager.Instance.button);

        //SoundManager.Instance.PlaySound(SoundManager.Instance.woosh);

        PolicyDialog.SetActive(false);

        // Hide the "I Agree" button
     //   agreeButton.gameObject.SetActive(false);

        // Resume the game
       // Time.timeScale = 1f;
    }

    public void OnAgreeButtonClicked()
    {
        // Set a player preference to indicate that the privacy policy has been agreed to
        PlayerPrefs.SetInt("privacyPolicyAgreed", 1);

        // Close the privacy policy dialog
        ClosePrivacyPolicyDialog();
    }

    public void openPrivacy() {
        //SoundManager.Instance.PlaySound(SoundManager.Instance.button);

        Application.OpenURL("#");
    }
}
