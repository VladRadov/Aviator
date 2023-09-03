using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberQuestion;

    [SerializeField] private Text _textQuestion;

    [SerializeField] private GameObject _content;

    [SerializeField] private AnswerView _prefabAnswer;

    public void OnLoadingQuestion(string numberQuestion, string textQuestion, List<string> answers)
    {
        _numberQuestion.text = numberQuestion;
        _textQuestion.text = textQuestion;
        CreateAnswers(answers);
    }

    private void CreateAnswers(List<string> answers)
    {
        PoolObjects<AnswerView>.DisactiveObjects();
        foreach (var textAnswers in answers)
        {
            var answer = PoolObjects<AnswerView>.GetObject(_prefabAnswer);
            answer.TextAnswer = textAnswers;
            answer.transform.SetParent(_content.transform, false);
            answer.EntryAnswer.onClick.RemoveAllListeners();
            answer.EntryAnswer.onClick.AddListener(() => { EventBus.InvokeEvents<INextQuestion>(question => question.NextQuestion()); });
            answer.EntryAnswer.onClick.AddListener(() => { EventBus.InvokeEvents<IPlayAudio>(player => player.PlayMusic(TypeAudioClip.Click)); });
        }
    }
}
