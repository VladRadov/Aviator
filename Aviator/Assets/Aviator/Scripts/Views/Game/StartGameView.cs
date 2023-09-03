using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class StartGameView : MonoBehaviour, ILoadingGamePayed
{
    [SerializeField] Button _buttonOpenGame;

    [SerializeField] Text _nameGame;

    [SerializeField] CodelessIAPButton _iapButton;

    public string GameName => _nameGame.text;

    private void Awake()
    {
        EventBus.Subscribe(this);
        _buttonOpenGame.onClick.AddListener(() => { EventBus.InvokeEvents<IPlayGame>(game => game.Play(this)); });
    }

    public void ChangeViewGamePayed()
    {
        if (_iapButton != null)
        {
            var purchasingGameView = transform.GetComponent<PurchasingGameView>();
            if (purchasingGameView != null)
                purchasingGameView.ChangeIcon();
            Destroy(_iapButton);
        }
    }

    public bool IsGamePayed() => _iapButton != null ? false : true;

    public void LoadingPayedGame(string nameGame)
    {
        if (StringHandler.RemoveChars(_nameGame.text, '\n') == nameGame)
            ChangeViewGamePayed();
    }
}
