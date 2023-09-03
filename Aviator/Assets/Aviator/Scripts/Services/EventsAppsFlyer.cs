using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsAppsFlyer : MonoBehaviour
{
    public static void OnPurchase(string price)
    {
        Dictionary<string, string> eventValues = new Dictionary<string, string>();
        eventValues.Add(AFInAppEvents.CURRENCY, "USA");
        eventValues.Add(AFInAppEvents.PURCHASE, price);
        AppsFlyer.sendEvent(AFInAppEvents.PURCHASE, eventValues);
    }

    public static void OnFinishTest()
    {
        Dictionary<string, string> eventValues = new Dictionary<string, string>();
        eventValues.Add(AFInAppEvents.EVENT_END, "Прохождение теста завершено!");
        AppsFlyer.sendEvent(AFInAppEvents.EVENT_END, eventValues);
    }

    public static void OnStartGame(string nameGame)
    {
        Dictionary<string, string> eventValues = new Dictionary<string, string>();
        eventValues.Add(AFInAppEvents.EVENT_START, nameGame);
        AppsFlyer.sendEvent(AFInAppEvents.EVENT_START, eventValues);
    }
}