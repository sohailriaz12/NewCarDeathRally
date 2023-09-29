using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class PTGoogleAdsInitialization : MonoBehaviour
{
    public GameObject bannerAdsGO;
    public GameObject interstitialAdsGO;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        MobileAds.Initialize(initStatus => {

            Debug.Log("Initialized Ads");
            bannerAdsGO.SetActive(true);
            interstitialAdsGO.SetActive(true);
        });
    }

}


