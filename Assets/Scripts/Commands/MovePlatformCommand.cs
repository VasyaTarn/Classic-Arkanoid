using strange.extensions.command.impl;

public class MovePlatformCommand : Command
{
    [Inject] public PlatformModel Model { get; private set; }
    [Inject] public float Direction { get; private set; }

    public override void Execute()
    {
        Model.Direction = Direction;
    }
}
