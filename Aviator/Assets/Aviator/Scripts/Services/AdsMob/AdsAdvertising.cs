using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public interface IAdsAdvertising
{
    void Show();

    void Destroy();
}

class AdsBanner : IAdsAdvertising
{
    private readonly string _unitId = "ca-app-pub-3940256099942544/2247696110";

    private BannerView _bannerView;

    public void Show()
    {
        if (_bannerView == null)
        {
            _bannerView = new BannerView(_unitId, AdSize.Leaderboard, AdPosition.Bottom);
            _bannerView.LoadAd(new AdRequest());
        }
    }

    public void Destroy()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
            this.Destroy();
        }
    }
}

class AdsInterstitialAdvertising : IAdsAdvertising
{
    private readonly string _unitId = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd _interstitialAd;

    public void Show()
    {
        var adRequest = new AdRequest();
        InterstitialAd.Load(_unitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError(error);
                    return;
                }
                _interstitialAd = ad;
            });

        if (_interstitialAd != null && _interstitialAd.CanShowAd())
            _interstitialAd.Show();
    }

    public void Destroy()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
            this.Destroy();
        }
    }

}