using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : BaseView
{
    [SerializeField] private Button _unpauseButton;
    [SerializeField] private RectTransform _hintTransform;

    public event Action UnpauseClicked;

    private Tween _hintTween;


    private void Start()
    {
        _unpauseButton.onClick.AddListener(() =>
        {
            if (UnpauseClicked != null)
            {
                UnpauseClicked();
            }
        });
    }

    public void PlayHintPulse()
    {
        if (_hintTransform == null) return;

        _hintTween?.Kill();

        _hintTween = _hintTransform
            .DOScale(1.1f, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);
    }

    public void StopHintPulse()
    {
        _hintTween?.Kill();
        _hintTween = null;

        if (_hintTransform != null)
        {
            _hintTransform.localScale = Vector3.one;
        }
    }
}
