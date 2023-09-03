using System.Collections.Generic;
using UnityEngine.Events;

public class TestsController : INextQuestion
{
    private Test _test;

    public UnityEvent<string, string, List<string>> LoadingQuestionEventHandler = new UnityEvent<string, string, List<string>>();

    public UnityEvent TestFinishedEventHandler = new UnityEvent();

    public TestsController(Test test)
    {
        _test = test;
        EventBus.Subscribe(this);
        ResetAnswer();
    }

    private void ResetAnswer()
    {
        foreach (var question in _test.Questions)
            question.IsAnswer = false;
    }

    public void FindQuestionNoAnswer()
    {
        foreach (var question in _test.Questions)
        {
            if (question.IsAnswer == false)
            {
                LoadingQuestionEventHandler?.Invoke(question.Number.ToString(), question.TextQuestion, question.Answers);
                question.IsAnswer = true;
                return;
            }
        }
        FinishedTest();
    }

    private void FinishedTest()
    {
        EventsAppsFlyer.OnFinishTest();
        ResetAnswer();
        NextQuestion();
        TestFinishedEventHandler?.Invoke();
    }

    public void NextQuestion() => FindQuestionNoAnswer();
}
