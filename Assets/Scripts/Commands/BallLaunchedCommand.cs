using strange.extensions.command.impl;

public class BallLaunchedCommand : Command
{
    [Inject] public IBallService BallService { get; private set; }


    public override void Execute()
    {
        BallService.Launch();
    }
}
