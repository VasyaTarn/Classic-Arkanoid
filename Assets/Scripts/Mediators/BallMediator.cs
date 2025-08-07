using strange.extensions.mediation.impl;
using UnityEngine;
using DG.Tweening;

public class BallMediator : Mediator
{
    [Inject] public BallView BallView { get; private set; }
    [Inject] public IBallService BallService { get; private set; }
    [Inject] public BallSkinChangedSignal BallSkinChangedSignal { get; private set; }
    [Inject] public IBallSkinsService BallSkinService { get; set; }

    private Tween _rotationTween;


    public override void OnRegister()
    {
        BallService.Init(BallView);
        BallView.OnBallCollision += BallService.OnCollision;
        BallSkinChangedSignal.AddListener(ChangeSkin);

        _rotationTween = BallView.transform
            .DORotate(new Vector3(0, 0, -360f), 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1);


    }

    public override void OnRemove()
    {
        BallView.OnBallCollision -= BallService.OnCollision;
        BallSkinChangedSignal.RemoveListener(ChangeSkin);

        _rotationTween?.Kill();
    }

    public void ChangeSkin()
    {
        BallView.GetComponent<SpriteRenderer>().sprite = BallSkinService.GetCurrent().sprite;
    }
}
