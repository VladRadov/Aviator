using UnityEngine;
using UnityEngine.UI;

public class AudioButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(() => { EventBus.InvokeEvents<IPlayAudio>(player => player.PlayMusic(TypeAudioClip.Click)); });
    }
}
