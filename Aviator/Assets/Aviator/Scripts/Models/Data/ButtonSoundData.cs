using UnityEngine;

[CreateAssetMenu(fileName = "ButtonSoundData", menuName = "ScriptableObject/ButtonSoundData")]
public class ButtonSoundData : ScriptableObject
{
    [SerializeField] private Sprite _icon;

    [SerializeField] private bool _isOn;

    public Sprite Icon => _icon;

    public bool IsOn => _isOn;
}
