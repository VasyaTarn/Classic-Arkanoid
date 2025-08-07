using strange.extensions.command.impl;

public class BallOutOfBoundsCommand : Command
{
    [Inject] public OpenLossScreenSignal OpenLossScreenSignal { get; private set; }


    public override void Execute()
    {
        OpenLossScreenSignal.Dispatch();
    }
}
