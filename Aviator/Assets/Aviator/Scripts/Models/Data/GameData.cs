using UnityEngine;

[CreateAssetMenu(fileName = "Game", menuName = "ScriptableObject/GameData")]
public class GameData : ScriptableObject, IGameData
{
    [SerializeField] protected string _name;

    [SerializeField] protected string _textGame;

    [SerializeField] protected bool _isPay;

    public string Name => _name;

    public string TextGame => _textGame;

    public bool IsPay => _isPay;
}
