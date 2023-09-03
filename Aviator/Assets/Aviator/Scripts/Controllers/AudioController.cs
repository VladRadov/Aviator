using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour, IPlayAudio
{
    [SerializeField] private List<AudioData> _audioClips;

    [SerializeField] private AudioSource _audioBackground;

    [SerializeField] private AudioSource _audioClick;

    [SerializeField] private Button _managerAudio;

    [SerializeField] private List<ButtonSoundData> _buttonSoundData;

    private bool _isAudioOn;

    private void Start() => Initialized();

    private void Initialized()
    {
        StateAudioOnStart();
        EventBus.Subscribe(this);     
        _managerAudio.onClick.AddListener(ChangeState);
    }

    private void StateAudioOnStart()
    {
        SetStatePlayer(true);
        SetIconManagerAudio(true);
        PlayMusic(TypeAudioClip.Background);
    }

    private void ChangeState()
    {
        switch (_isAudioOn)
        {
            case false:
                {
                    SetStatePlayer(true);
                    PlayMusic(TypeAudioClip.Click);
                    PlayMusic(TypeAudioClip.Background);
                    SetIconManagerAudio(true);
                    break;
                }
            case true:
                {
                    SetStatePlayer(false);
                    PauseAllPlayer();
                    SetIconManagerAudio(false);
                    break;
                }
        }
    }

    public void SetStatePlayer(bool value) => _isAudioOn = value;

    private void SetIconManagerAudio(bool value)
    {
        var buttonData = _buttonSoundData.Find(buttonData => buttonData.IsOn == value);
        if (buttonData != null)
            _managerAudio.image.sprite = buttonData.Icon;
    }

    public void PlayMusic(TypeAudioClip typeAudio)
    {
        var audio = FindTypeMusic(typeAudio);
        if (audio != null)
        {
            switch (typeAudio)
            {
                case TypeAudioClip.Click:
                    {
                        _audioClick.clip = audio.Music;
                        _audioClick.Play();
                        break;
                    }
                case TypeAudioClip.Background:
                    {
                        _audioBackground.clip = audio.Music;
                        _audioBackground.Play();
                        break;
                    }
            }
        }
    }

    public void PauseAllPlayer()
    {
        _audioBackground.Stop();
        _audioClick.Stop();
    }

    private AudioData FindTypeMusic(TypeAudioClip typeAudio) =>  _audioClips.Find(audioClips => audioClips.TypeAudio == typeAudio);
}
