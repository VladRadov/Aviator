using UnityEngine;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour
{
    [SerializeField] private Text _text;

    [SerializeField] private Button _entryAnswer;

    public string TextAnswer { get { return _text.text; } set { _text.text = value; } }

    public Button EntryAnswer => _entryAnswer;
}