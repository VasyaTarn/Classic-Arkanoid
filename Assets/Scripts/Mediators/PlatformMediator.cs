using strange.extensions.mediation.impl;
using UnityEngine;

public class PlatformMediator : Mediator
{
    [Inject] public PlatformView View { get; private set; }
    [Inject] public PlatformModel Model { get; private set; }
    [Inject] public PlatformTickSignal TickSignal { get; private set; }
    [Inject] public ResetPlatformPositionSignal ResetPlatformPositionSignal { get; private set; }

    private float _threshold = 0.01f;


    public override void OnRegister()
    {
        Model.StartPosition = View.transform.position;

        Model.Initialize(View.GetComponent<Collider2D>());

        TickSignal.AddListener(OnTick);

        ResetPlatformPositionSignal.AddListener(ResetPosition);
    }

    public override void OnRemove()
    {
        TickSignal.RemoveListener(OnTick);
        ResetPlatformPositionSignal.RemoveListener(ResetPosition);
    }

    private void OnTick()
    {
        if (Mathf.Abs(Model.Direction) > _threshold)
        {
            var direction = Model.Direction * Model.Speed * Time.deltaTime;

            Model.Move(Time.deltaTime);
            View.SetPositionX(Model.PositionX);
        }
    }

    private void ResetPosition()
    {
        View.gameObject.transform.position = Model.StartPosition;
        Model.PositionX = 0f;
    }
}
