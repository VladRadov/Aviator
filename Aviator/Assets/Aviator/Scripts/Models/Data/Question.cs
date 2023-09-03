using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObject/Question")]
public class Question : ScriptableObject
{
    [SerializeField] private int _number;

    [SerializeField] private string _textQuestion;

    [SerializeField] private List<string> _answers;

    [SerializeField] private bool _isAnswer;

    public int Number => _number;

    public string TextQuestion => _textQuestion;

    public List<string> Answers => _answers;

    public bool IsAnswer { get { return _isAnswer; } set { _isAnswer = value; } }
}
