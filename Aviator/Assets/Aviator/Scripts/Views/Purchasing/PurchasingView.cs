using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;

public class PurchasingView : BasePurchasingView
{
    public UnityEvent<Product> OnPurchaseCompletedEventHandler = new UnityEvent<Product>();

    public void OnPurchaseCompleted(Product product) => OnPurchaseCompletedEventHandler?.Invoke(product);
}