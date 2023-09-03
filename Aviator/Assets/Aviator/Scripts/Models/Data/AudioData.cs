using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObject/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] private TypeAudioClip _typeAudioClip;

    [SerializeField] private AudioClip _music;

    public TypeAudioClip TypeAudio => _typeAudioClip;

    public AudioClip Music => _music;
}
