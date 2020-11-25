using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class Main : MonoBehaviour
{
    Admob ad;
    void Awake()
    {
        Debug.Log("Awake is called!----------");
        AdProperties adProperties = new AdProperties();
        adProperties.isTesting(true);
        adProperties.isAppMuted(true);
        adProperties.isUnderAgeOfConsent(false);
        adProperties.appVolume(100);
        adProperties.maxAdContentRating(AdProperties.maxAdContentRating_G);
        string[] keywords = { "diagram", "league", "brambling" };
        adProperties.keyworks(keywords);

        ad = Admob.Instance();
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.initSDK(adProperties);
    }

    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);

        if (eventName == AdmobEvent.onAdLoaded)         //广告加载完成
        {
            ad.showRewardedVideo();
        }


        if (eventName == AdmobEvent.onRewarded)         //广告看完获取奖励
        {
            //ad.showRewardedVideo();
        }

        if (eventName == AdmobEvent.onAdClosed)         //广告关闭
        {
            //ad.showRewardedVideo();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 200), "showRewardVideo"))
        {
            Debug.Log("touch video button -------------");
            if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
                ad.loadRewardedVideo("ca-app-pub-6424827618816093/9672933200");
            }
        }
 
    }
}
