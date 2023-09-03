using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button _close;

    private void Start()
    {
        _close.onClick.AddListener(CloseGame);
    }

    private void SetActiveGame(bool isActive) => gameObject.SetActive(isActive);

    public void CloseGame()
    {
        EventBus.InvokeEvents<ISetActiveLamps>(lamps => lamps.TurnOnLamps());
        EventBus.InvokeEvents<IBlurBackground>(background => background.DisableBlur());
        SetActiveGame(false);
    }

    public void OpenGame()
    {
        EventBus.InvokeEvents<ISetActiveLamps>(lamps => lamps.TurnOffLamps());
        EventBus.InvokeEvents<IBlurBackground>(background => background.ShowBlurBackground());
        SetActiveGame(true);
    }
}
