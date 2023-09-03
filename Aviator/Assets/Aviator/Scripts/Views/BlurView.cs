using UnityEngine;
using UnityEngine.UI;

public class BlurView : MonoBehaviour, IBlurBackground
{
    private bool _isView;

    private const float _speedBlur = 0.05f;

    [SerializeField] private Image _image;

    private void Start()
    {
        gameObject.SetActive(false);
        EventBus.Subscribe(this);
        _isView = false;
    }

    private void FixedUpdate()
    {
        if (_isView)
        {
            if (_image.color.a < 1)
                SlowBlur();
            else
                _isView = false;
        }
    }

    private void SlowBlur() => _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a + _speedBlur);

    public void ShowBlurBackground()
    {
        gameObject.SetActive(true);
        _isView = true;
    }

    public void DisableBlur()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
        gameObject.SetActive(false);
    }
}
