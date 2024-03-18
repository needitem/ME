using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
 
// 구글 애드몹 전면광고 코드
//https://parksh3641.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-C-%EA%B5%AC%EA%B8%80-%EC%95%A0%EB%93%9C%EB%AA%B9-Google-Admob-%EC%A0%84%EB%A9%B4-%EA%B4%91%EA%B3%A0-%EA%B0%84%EB%8B%A8-%EC%A0%81%EC%9A%A9%EB%B2%95
// 해당 블로그 참고
public class AdmobManager : MonoBehaviour
{
    string adUnitId;

    private InterstitialAd interstitialAd;

    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            //초기화 완료
        });

#if UNITY_ANDROID
        adUnitId = ""; //광고단위ID
#else
        adUnitId = "unexpected_platform";
#endif

        LoadInterstitialAd();
    }

    public void LoadInterstitialAd() //광고 로드
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        var adRequest = new AdRequest.Builder()
                .AddKeyword("unity-admob-sample")
                .Build();

        InterstitialAd.Load(adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
        RegisterEventHandlers(interstitialAd); //이벤트 등록
    }

    public void ShowAd() //광고 보기
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            LoadInterstitialAd(); //광고 재로드

            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterEventHandlers(InterstitialAd ad) //광고 이벤트
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {

            //보상 주기

            Debug.Log(string.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

  
}