using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowTypeDisableAdvertisingView : BaseAdvertisingView
{
    [SerializeField] private Button _showTypeDisableAdvertising;

    public void AddListenerButtinClick(params UnityAction[] actions)
    {
        foreach(var action in actions)
            _showTypeDisableAdvertising.onClick.AddListener(action);
    }
}
