using strange.extensions.command.impl;

public class ResetGameCommand : Command
{
    [Inject] public ResetPlatformPositionSignal ResetPlatformPositionSignal { get; private set; }
    [Inject] public IBallService BallService { get; private set; }
    [Inject] public BricksService BricksService { get; private set; }
    [Inject] public IStateMachine StateMachine { get; private set; }
    [Inject] public AppStartSignal AppStartSignal { get; private set; }
    [Inject] public GameModel GameModel { get; private set; }


    public override void Execute()
    {
        ResetPlatformPositionSignal.Dispatch();

        BallService.ResetPosition();

        BricksService.EnableBricks();

        StateMachine.UnloadActiveStates();

        GameModel.ResetScore();

        AppStartSignal.Dispatch();
    }
}
