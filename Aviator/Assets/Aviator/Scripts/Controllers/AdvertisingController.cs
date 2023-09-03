using System.Collections.Generic;
using UnityEngine.Purchasing;

public class AdvertisingController : IChangeStateAdvertising, IPurchaseAdvertising, IPlayGame
{
    private Advertising _advertising;

    private List<BaseAdvertisingView> _elementsAdvertising;

    private ShowTypeDisableAdvertisingView _showTypeDisableAdvertisingView;

    private MenuTypesDiableAdverstising _menuTypesDiableAdverstising;

    private AdsManager _adsManager;

    public void Initialized(List<BaseAdvertisingView> elementsAdvertising)
    {
        _elementsAdvertising = elementsAdvertising;
        SetElementsAdverstisingView();

        _advertising = new Advertising();
        _adsManager = new AdsManager(new AdsBanner(), new AdsInterstitialAdvertising());

        Subscribe();
        _advertising.Initialized();
    }

    private void SetElementsAdverstisingView()
    {
        _showTypeDisableAdvertisingView = FindObject<ShowTypeDisableAdvertisingView>();
        _menuTypesDiableAdverstising = FindObject<MenuTypesDiableAdverstising>();
    }

    private void Subscribe()
    {
        EventBus.Subscribe(this);
        _showTypeDisableAdvertisingView.AddListenerButtinClick(() => { EventBus.InvokeEvents<ISetActiveLamps>(lamps => lamps.TurnOffLamps()); });
        _showTypeDisableAdvertisingView.AddListenerButtinClick(() => { ShowMenuTypesDiableAdverstising(true); });
        _showTypeDisableAdvertisingView.AddListenerButtinClick(() => { EventBus.InvokeEvents<IBlurBackground>(background => background.ShowBlurBackground()); });
    }

    private void ShowMenuTypesDiableAdverstising(bool value) => _menuTypesDiableAdverstising.SetActiveMenu(value);

    public T FindObject<T>() where T : BaseAdvertisingView
    {
        var typesSubscriber = _elementsAdvertising.Find(element => element.GetType() ==  typeof(T));
        return (T)typesSubscriber;
    }

    public void ChangeStateAdvertising(StateAdvertising stateAdvertising)
    {
        if (stateAdvertising == StateAdvertising.Disable)
        {
            _showTypeDisableAdvertisingView.gameObject.SetActive(false);
            _menuTypesDiableAdverstising.CloseMenu();
        }
    }

    public void OnPurchaseCompleted(TypeDisableAdvertising typeDisabel)
    {
        _advertising.DisableAdvertising(typeDisabel);
        _showTypeDisableAdvertisingView.gameObject.SetActive(false);
        _menuTypesDiableAdverstising.CloseMenu();
    }

    public void Play(StartGameView game) => _adsManager.FindObject<AdsInterstitialAdvertising>()?.Show();
}
