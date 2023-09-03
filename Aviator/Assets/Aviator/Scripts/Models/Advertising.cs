using System;
using UnityEngine;

public class Advertising
{
    private StateAdvertising _state;

    private const int DISABLE_SEVEN_DAYS = 7;

    private const int DISABLE_ONE_MONTH = 30;

    private AdvertisingStorageData _storageData;

    public void Initialized()
    {
        _storageData = new AdvertisingStorageData();
        CheckState();
    }

    public void DisableAdvertising(TypeDisableAdvertising typeDisable)
    {
        int quantityDays = 0;
        switch (typeDisable)
        {
            case TypeDisableAdvertising.SevenDays:
                quantityDays = DISABLE_SEVEN_DAYS;
                break;
            case TypeDisableAdvertising.OneMonth:
                quantityDays = DISABLE_ONE_MONTH;
                break;
        }
        _storageData.SaveDateDisable(DateTime.Now.ToString());
        _storageData.SaveQuantityDays(quantityDays);

        _state = StateAdvertising.Disable;
        EventBus.InvokeEvents<IChangeStateAdvertising>(state => state.ChangeStateAdvertising(_state));
    }

    public void CheckState()
    {
        var dateDisable = _storageData.GetDateDisable();
        var quantityDays = _storageData.GetQuantityDays();
        if (dateDisable != null && quantityDays != 0)
        {
            if (DateTime.Now > DateTime.Parse(dateDisable).AddDays(quantityDays))
                EnableAdvertising();
            else
                _state = StateAdvertising.Disable;
        }
        else
            _state = StateAdvertising.Enable;

        EventBus.InvokeEvents<IChangeStateAdvertising>(state => state.ChangeStateAdvertising(_state));
    }

    private void EnableAdvertising()
    {
        _storageData.DeleteData();
        _state = StateAdvertising.Enable;
    }
}
