using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour, IChangeStateAdvertising
{
    private List<IAdsAdvertising> _adsAdvertisings = new List<IAdsAdvertising>();

    public AdsManager(params IAdsAdvertising[] adsAdvertisings)
    {
        _adsAdvertisings.AddRange(adsAdvertisings);
        EventBus.Subscribe(this);
    }

    public void Initialized()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize((InitializationStatus) => 
        {
            FindObject<AdsBanner>().Show();
        });
    }

    public T FindObject<T>() where T : IAdsAdvertising
    {
        var adsAdvertisings = _adsAdvertisings.Find(element => element.GetType() == typeof(T));
        return (T)adsAdvertisings;
    }

    private void Disable()
    {
        foreach (var ads in _adsAdvertisings)
            ads.Destroy();

        _adsAdvertisings.Clear();
    }

    public void ChangeStateAdvertising(StateAdvertising typeDisableAdvertising)
    {
        switch (typeDisableAdvertising)
        {
            case StateAdvertising.Enable:
                Initialized();
                break;
            case StateAdvertising.Disable:
                Disable();
                break;
        }
    }
}