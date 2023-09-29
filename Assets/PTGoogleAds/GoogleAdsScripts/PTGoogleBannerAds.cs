using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class PTGoogleBannerAds : MonoBehaviour
{

    [SerializeField]private int adWidth=320;
    [SerializeField] private int adHeight=50;
    [SerializeField] private AdPosition adPosition = AdPosition.Bottom;



    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-2036900479884242/5457355201";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-2036900479884242/7475399488";
#else
  private string _adUnitId = "unused";
#endif

    BannerView _bannerView;

    // Start is called before the first frame update
    void OnEnable()
    {
        LoadAd();
    }



    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView(adWidth,adHeight,adPosition);
        }
        // create our request used to load the ad.
        var adRequest = new AdRequest();
        //adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);

    }



    /// <summary>
    /// listen to events the banner may raise.
    /// </summary>
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + _bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }






    // <summary>
    /// Creates a custom banner at defined position.
    /// </summary>
    public void CreateBannerView(int bannerWidth,int bannerHeight, AdPosition adPosition)
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyAd();
        }


        // Use the AdSize argument to set a custom size for the ad.
        AdSize adSize = new AdSize(bannerWidth, bannerHeight);
        _bannerView = new BannerView(_adUnitId, adSize, adPosition);
        ListenToAdEvents();


    }






    /// <summary>
    /// Destroys the ad.
    /// </summary>
    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner ad.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

}
