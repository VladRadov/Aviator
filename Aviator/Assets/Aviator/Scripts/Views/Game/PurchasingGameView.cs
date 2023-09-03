using System.Collections.Generic;
using UnityEngine;

public class PurchasingGameView : MonoBehaviour
{
    [SerializeField] private List<PayView> _elementsPay;

    [SerializeField] private PayedView _elementPayed;

    public void ChangeIcon()
    {
        DisableElementsPay();
        EnableElementPayed();
    }

    private void DisableElementsPay()
    {
        foreach (var element in _elementsPay)
            element.gameObject.SetActive(false);
    }

    private void EnableElementPayed() => _elementPayed.gameObject.SetActive(true);
}
