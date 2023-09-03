using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStorageData
{
    public virtual void DeleteData(params string[] keys)
    {
        foreach(var key in keys)
            PlayerPrefs.DeleteKey(key);
    }
}

public class AdvertisingStorageData : PlayerPrefsStorageData
{
    private readonly string DATE_DISABLE = "DATE_DISABLE";

    private readonly string QUANTITY_DAYS = "QUANTITY_DAYS";

    public void SaveDateDisable(string dateTime) => PlayerPrefs.SetString(DATE_DISABLE, dateTime);

    public void SaveQuantityDays(int quantityDays) => PlayerPrefs.SetInt(QUANTITY_DAYS, quantityDays);

    public string GetDateDisable() => PlayerPrefs.GetString(DATE_DISABLE);

    public int GetQuantityDays() => PlayerPrefs.GetInt(QUANTITY_DAYS);

    public override void DeleteData(params string[] keys) => base.DeleteData(DATE_DISABLE, QUANTITY_DAYS);
}

public class PayGameStorageData : PlayerPrefsStorageData
{
    private readonly string PAYED_GAMES = "PAYED_GAMES";

    public void SaveGamePayed(string nameGame)
    {
        var payedGames = PlayerPrefs.GetString(PAYED_GAMES);
        PlayerPrefs.SetString(PAYED_GAMES, string.IsNullOrWhiteSpace(payedGames) ? nameGame : payedGames + "," + nameGame);
    }

    public string GetGamePayed() => PlayerPrefs.GetString(PAYED_GAMES);
}
