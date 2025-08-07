using strange.extensions.command.impl;
public class LoadStateCommand<T> : Command where T : IState
{
    [Inject] public IStateMachine StateMachine { get; set; }


    public override void Execute()
    {
        StateMachine.Load(injectionBinder.GetInstance<T>());
    }
}
