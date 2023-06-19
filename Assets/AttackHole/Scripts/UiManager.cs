using BeautifulTransitions.Scripts.Transitions;
using DxCoder;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private bool gameStarted = false;
    public GameObject BottomBanner, Shopbutton, magnetbutton, timerbutton, RewardButton;

    // Start is called before the first frame update
    public static UiManager instane;
    private void Awake()
    {
        instane = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            HideUi();
        }
     

        // Add code here to start the game, e.g. load the first level
    }
    public void HideUi()
    {
       // SoundManager.Instance.PlaySound(SoundManager.Instance.woosh);
        TransitionHelper.TransitionOut(BottomBanner);
        TransitionHelper.TransitionOut(Shopbutton);
        TransitionHelper.TransitionOut(RewardButton);
        TransitionHelper.TransitionOut(magnetbutton);
        TransitionHelper.TransitionOut(timerbutton);
    }
}
