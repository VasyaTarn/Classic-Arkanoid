using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunnerMediator : Mediator
{
    [Inject] public GameRunnerView View { get; private set;}
    [Inject] public IInputControl PlatformInput { get; private set;}
    [Inject] public PlatformTickSignal PlatformTickSignal { get; private set;}
    [Inject] public MovePlatformSignal MovePlatformSignal { get; private set;}
    [Inject] public GameState GameState { get; private set; }

    public override void OnRegister()
    {
        View.OnTick += OnTick;

        GameState.InitializeWithView(View);
    }

    public override void OnRemove()
    {
        View.OnTick -= OnTick;
    }

    private void OnTick()
    {
        PlatformTickSignal.Dispatch();

        if (PlatformInput != null && Mathf.Abs(PlatformInput.Direction) > 0.01f)
        {
            MovePlatformSignal.Dispatch(PlatformInput.Direction);
        }
    }
}
