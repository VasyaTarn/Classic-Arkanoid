using strange.extensions.mediation.impl;
using UnityEngine;

public class FixedGameRunnderMediator : Mediator
{
    [Inject] public FixedGameRunnderView View { get; private set; }
    [Inject] public IBallService BallService { get; private set; }


    public override void OnRegister()
    {
        View.OnFixedTick += OnFixedTick;
        View.EnableTick();
    }

    public override void OnRemove()
    {
        View.OnFixedTick -= OnFixedTick;
    }

    private void OnFixedTick()
    {
        BallService.EnforceBallSpeed();
    }
}
