using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class MenuTypesDiableAdverstising : BaseAdvertisingView
{
    [SerializeField] private GameObject _menuTypesDiableAdverstising;

    [SerializeField] private Button _closeMenu;

    [SerializeField] private Button _disableAdverstisingSevenDays;

    [SerializeField] private Button _disableAdverstisingOneMonth;

    public UnityEvent<Product> PurchaseCompletedEventHandler = new UnityEvent<Product>();

    private void Start()
    {
        _closeMenu.onClick.AddListener(CloseMenu);
    }

    public void SetActiveMenu(bool value)
    {
        gameObject.SetActive(value);
    }

    public void CloseMenu()
    {
        EventBus.InvokeEvents<ISetActiveLamps>(lamps => lamps.TurnOnLamps());
        EventBus.InvokeEvents<IBlurBackground>(background => background.DisableBlur());
        SetActiveMenu(false);
    }
}
