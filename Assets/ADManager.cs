 using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ADManager : MonoBehaviour
{
    public enum BannerPositionEnum
    {
        Top,
        Bottom
    }
    public BannerPositionEnum BannerPosition;// = BannerPosition.Top;

    private RewardedAd rewardedAd;
    private static ADManager _instance;
    InterstitialAd interstitial;
    BannerView bannerView;
    string bannerID, interstitialID, rewardedVideoID;
    public bool TestADS = false;

    public float InterstitialTime;
    public float IntersitialAdTime;

    public float VideoTime;
    public float VideoAdTime;

    public GameObject Video;

    public bool UseAds;

    public bool Android;

    public string AndroidBanner;
    public string AndroidIntersitial;
    public string AndroidVideo;

    void Update()
    {
        InterstitialTime += UnityEngine.Time.deltaTime;
        VideoTime += UnityEngine.Time.deltaTime;
        if (Video != null)
        {
            if (VideoTime > VideoAdTime)
            {
                Video.SetActive(true);
            }
            else
            {
                Video.SetActive(false);
            }
        }
        
    }
    public static ADManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ADManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void Start ()
    {
        if (TestADS == true)
        {
            bannerID = "ca-app-pub-3940256099942544/6300978111";
            interstitialID = "ca-app-pub-3940256099942544/1033173712";
            rewardedVideoID = "ca-app-pub-3940256099942544/5224354917";
        }
        else
        {
            
            if(Android == true)
            {
                //android
                bannerID = AndroidBanner;
                interstitialID = AndroidIntersitial;
                rewardedVideoID = AndroidVideo;
            }
            else
            {
                //ios 
                bannerID = "ca-app-pub-3817234383209052/1147597655";
                interstitialID = "ca-app-pub-3817234383209052/8646813722";
                rewardedVideoID = "ca-app-pub-3817234383209052/3377626433";
            }




        }

        RequestBanner();
        RequestInterstitial();
        RequestRewardBasedVideo();
    }

    public void ShowBanner ()
    {
        if(UseAds == false)
        {
            return;
        }
        if (bannerView != null)
        {
            bannerView.Show();
        }
    }

    public void HideBanner ()
    {
        if (bannerView != null)
        {
            bannerView.Hide();
        }
    }
    private void RequestBanner ()
    {
        if(BannerPosition == BannerPositionEnum.Top)
        this.bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);
        if (BannerPosition == BannerPositionEnum.Bottom)
            this.bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        this.bannerView.Hide();
    }
    void RequestInterstitial ()
    {
        this.interstitial = new InterstitialAd(interstitialID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleInterstitialOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleInterstitialOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleInterstitialOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleInterstitialOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleInterstitialOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    private AdRequest CreateAdRequest ()
    {
        return new AdRequest.Builder().Build();
    }
    public void RequestRewardBasedVideo ()
    {
        this.rewardedAd = new RewardedAd(rewardedVideoID);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // Create an empty ad request.

        rewardedAd.LoadAd(CreateAdRequest());
    }
    
    public void ShowInterstitial ()
    {
        if (UseAds == false)
        {
            return;
        }
        if (PlayerPrefs.GetInt("RemoveAD") == 0)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
                RequestInterstitial();
            }
            else
            {
                RequestInterstitial();
            }
        }
    }
   
    public void ShowRewardedVideo ()
    {
        if (UseAds == false)
        {
            return;
        }
        VideoTime = 0;
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }
        else
        {
            RequestRewardBasedVideo();
        }
    }

    public void HandleOnAdLoaded (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
        //MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "+ args.Message);
    }

    public void HandleOnAdOpened (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void HandleInterstitialOnAdLoaded (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleInterstitialOnAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
    {
        RequestInterstitial();
        //MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "+ args.Message);
    }

    public void HandleInterstitialOnAdOpened (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleInterstitialOnAdClosed (object sender, EventArgs args)
    {
        RequestInterstitial();
        //MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleInterstitialOnAdLeavingApplication (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void HandleRewardedAdLoaded (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad (object sender, AdErrorEventArgs args)
    {
        RequestRewardBasedVideo();

        //MonoBehaviour.print("HandleRewardedAdFailedToLoad event received with message: "+ args.Message);
    }

    public void HandleRewardedAdOpening (object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow (object sender, AdErrorEventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdFailedToShow event received with message: "+ args.Message);
    }

    public void HandleRewardedAdClosed (object sender, EventArgs args)
    {
        RequestRewardBasedVideo();
        //MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward (object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
        UpgradeScript.Money += 15;
        //Debug.Log("");
        //MonoBehaviour.print("HandleRewardedAdRewarded event received for "+ amount.ToString() + " " + type);
    }
    
}
