using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchasingController
{
    private List<BasePurchasingView> _elementsPurchasing;

    private PurchasingView _purchasingView;

    public void Initialized(List<BasePurchasingView> elementsPurchasing)
    {
        _elementsPurchasing = elementsPurchasing;
        _purchasingView = FindObject<PurchasingView>();
        Subscribe();
    }

    private void Subscribe()
    {
        _purchasingView.OnPurchaseCompletedEventHandler.AddListener(Purchase);
    }

    public T FindObject<T>() where T : BasePurchasingView
    {
        var typesSubscriber = _elementsPurchasing.Find(element => element.GetType() == typeof(T));
        return (T)typesSubscriber;
    }

    public void Purchase(Product advertising)
    {
        float price = 0;
        switch (advertising.definition.id)
        {
            case "com.koshwordfl.yguide.removeadds7":
                {
                    price = 7;
                    EventBus.InvokeEvents<IPurchaseAdvertising>(advertising => advertising.OnPurchaseCompleted(TypeDisableAdvertising.SevenDays));
                    break;
                }
            case "com.koshwordfl.yguide.removeadds1Moth":
                {
                    price = 14;
                    EventBus.InvokeEvents<IPurchaseAdvertising>(advertising => advertising.OnPurchaseCompleted(TypeDisableAdvertising.OneMonth));
                    break;
                }
            case "com.koshwordfl.yguide.gameMoon":
                {
                    price = 0.99f;
                    EventBus.InvokeEvents<IPurchaseGame>(game => game.OnPurchaseCompleted());
                    break;
                }
            case "com.koshwordfl.yguide.game2019":
                {
                    price = 1.99f;
                    EventBus.InvokeEvents<IPurchaseGame>(game => game.OnPurchaseCompleted());
                    break;
                }
            case "com.koshwordfl.yguide.gameBigX":
                {
                    price = 2.99f;
                    EventBus.InvokeEvents<IPurchaseGame>(game => game.OnPurchaseCompleted());
                    break;
                }
            case "com.koshwordfl.yguide.gamePariMatch":
                {
                    price = 3.99f;
                    EventBus.InvokeEvents<IPurchaseGame>(game => game.OnPurchaseCompleted());
                    break;
                }
            case "com.koshwordfl.yguide.gameAvia360":
                {
                    price = 99.99f;
                    EventBus.InvokeEvents<IPurchaseGame>(game => game.OnPurchaseCompleted());
                    break;
                }
        }

        EventsAppsFlyer.OnPurchase(price.ToString());
    }
}
