using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealManager : MonoBehaviour, IAppodealInitializationListener
{
    public void Initialized()
    {
        int adTypes = Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO | Appodeal.MREC;
        string appKey = "b8f8b46da4eb73bbfa9df35df27e123ba161a1d1400d1811";
        Appodeal.initialize(appKey, adTypes, (IAppodealInitializationListener)this);
    }

    public void ShowBanner()
    {
        Appodeal.show(Appodeal.BANNER_BOTTOM);
    }

    public void onInitializationFinished(List<string> errors)
    {

    }
}
