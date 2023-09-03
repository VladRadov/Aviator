using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour, IPlayGame, IPurchaseGame
{
    private OneSignalController _oneSignalController;

    private AdvertisingController _advertisingController;

    private PurchasingController _purchasingController;

    private StartGameView _viewCurrentGame;

    private GameData _currentGame;

    private PayGameStorageData _storageData;

    //TODO: private AppodealManager _appodealManager;

    [SerializeField] private List<GameData> _games;

    [SerializeField] private GameView _panelGame;

    [SerializeField] private TextMeshProUGUI _textGame;

    [SerializeField] private TestView _testView;

    [SerializeField] private List<BaseAdvertisingView> _elementsAdvertising;

    [SerializeField] private List<BasePurchasingView> _elementsPurchasing;

    private void Start()
    {
        EventBus.Subscribe(this);

        _storageData = new PayGameStorageData();

        _oneSignalController = new OneSignalController();
        _advertisingController = new AdvertisingController();
        _purchasingController = new PurchasingController();

        Initialized();
        _testView.Initialized();
        _oneSignalController.Initialized();
        _advertisingController.Initialized(_elementsAdvertising);
        _purchasingController.Initialized(_elementsPurchasing);
    }

    private void Initialized()
    {
        LoadPayedGames();
    }

    private void LoadPayedGames()
    {
        var storagePayedGames = _storageData.GetGamePayed();
        foreach (var game in _games)
            CheckingGameOnPayed(game, storagePayedGames);
    }

    private void CheckingGameOnPayed(GameData game, string storagePayedGames)
    {
        if (game.IsPay && storagePayedGames.Contains(game.Name))
            EventBus.InvokeEvents<ILoadingGamePayed>(gamePayed => gamePayed.LoadingPayedGame(game.Name));
    }

    public void Play(StartGameView game)
    {
        _viewCurrentGame = game;
        _currentGame = FindGame(game.GameName);
        if (_currentGame != null && _viewCurrentGame.IsGamePayed())
            ShowGame();
    }

    private void ShowGame()
    {
        _panelGame.OpenGame();
        _textGame.text = _currentGame.TextGame;
        EventsAppsFlyer.OnStartGame(_currentGame.Name);
    }

    private GameData FindGame(string gameName) => _games.Find(game => StringHandler.RemoveChars(game.Name, '\n') == StringHandler.RemoveChars(gameName, '\n'));

    public void OnPurchaseCompleted()
    {
        _viewCurrentGame.ChangeViewGamePayed();
        _storageData.SaveGamePayed(_currentGame.Name);
        ShowGame();
    }
}
