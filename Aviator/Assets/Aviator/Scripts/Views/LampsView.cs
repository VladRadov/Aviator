using System.Collections.Generic;
using UnityEngine;

public class LampsView : MonoBehaviour, ISetActiveLamps
{
    [SerializeField] private List<GameObject> _lamps;

    private void Start()
    {
        EventBus.Subscribe(this);
    }

    public void TurnOnLamps() => SetActiveLamps(true);

    public void TurnOffLamps() => SetActiveLamps(false);

    private void SetActiveLamps(bool value)
    {
        foreach (var lamp in _lamps)
            lamp.SetActive(value);
    }
}
