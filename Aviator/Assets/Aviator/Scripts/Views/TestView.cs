using UnityEngine;
using UnityEngine.UI;

public class TestView : MonoBehaviour
{
    private TestsController _testsController;

    [SerializeField] private Button _openTest;

    [SerializeField] private Button _closeTest;

    [SerializeField] private Test _test;

    [SerializeField] private QuestionView _questionView;

    private void Start()
    {
        _testsController = new TestsController(_test);
        Subscribe();
        _testsController.FindQuestionNoAnswer();
    }

    private void Subscribe()
    {
        _testsController.LoadingQuestionEventHandler.AddListener(_questionView.OnLoadingQuestion);
        _testsController.TestFinishedEventHandler.AddListener(CloseTest);
        _closeTest.onClick.AddListener(CloseTest);
    }

    public void Initialized() => _openTest.onClick.AddListener(() => { OpenTest();});

    private void SetActiveTest(bool isActive) => gameObject.SetActive(isActive);

    public void CloseTest()
    {
        EventBus.InvokeEvents<ISetActiveLamps>(lamps => lamps.TurnOnLamps());
        EventBus.InvokeEvents<IBlurBackground>(background => background.DisableBlur());
        SetActiveTest(false);
    }

    public void OpenTest()
    {
        EventBus.InvokeEvents<ISetActiveLamps>(lamps => lamps.TurnOffLamps());
        EventBus.InvokeEvents<IBlurBackground>(background => background.ShowBlurBackground());
        SetActiveTest(true);
    }
}
