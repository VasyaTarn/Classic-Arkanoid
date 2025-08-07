using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuScreen : BaseView
{
    [SerializeField] private Button _chooseBallBtn;

    [SerializeField] private Image _ballImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private CanvasGroup _light;

    public Button LeftButton => _leftButton;
    public Button RightButton => _rightButton;

    public event Action ChooseClicked;

    private Tween _lightTween;


    private void Start()
    {
        _chooseBallBtn.onClick.AddListener(() =>
        {
            if (ChooseClicked != null)
            {
                ChooseClicked();
            }
        });
    }

    public void SetSkin(BallElement element)
    {
        _ballImage.sprite = element.sprite;
        _nameText.text = element.name;
    }

    public void PlayLightPulse()
    {
        _lightTween?.Kill(true);

        _lightTween = DOTween.Sequence()
            .Append(_light.DOFade(0.4f, 1f))
            .Append(_light.DOFade(1f, 1f))
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.InOutSine)
            .SetUpdate(true);
    }

    public void StopLightPulse()
    {
        _lightTween?.Kill(true);
        _lightTween = null;

        _light.alpha = 1f;
    }
}
