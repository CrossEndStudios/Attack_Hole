using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameInfo", menuName ="DxCoder/GameInfo")]
public class GameInfo : ScriptableObject
{
    public Sprite Icon;
    public string appName;
    public string appVersion;
    public string moreGamesUrl;
    public string rateUsUrl;
    public string PrivacyPolicy;
    public string TernAndCondition;
    [Header("Rewards")]
    public string DailyRewardInterval;
    public string DailyRewardCoins;
    [Header("Ads")]
    public string AdmobAppID;
    public string AdmobBanner;
    public string AdmobInterstitial;
    public string AdmobReward;
}
