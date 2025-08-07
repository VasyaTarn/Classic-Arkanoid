using strange.extensions.injector.api;
using UnityEngine;
using UnityEngine.Windows;

public class GameContext : SignalContext, ICustomContext
{
    private readonly IInputControl _input;


    public GameContext(MonoBehaviour contextView, IInputControl input, ICrossContextInjectionBinder rootBinder) : base(contextView)
    {
        _input = input;

        this.injectionBinder = rootBinder;
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        // Signals

        injectionBinder.Bind<MovePlatformSignal>().ToSingleton();
        injectionBinder.Bind<PlatformTickSignal>().ToSingleton();

        // Models

        injectionBinder.Bind<PlatformModel>().ToSingleton();

        // Commands

        commandBinder.Bind<MovePlatformSignal>().To<MovePlatformCommand>();

        // Mediation

        mediationBinder.Bind<PlatformView>().To<PlatformMediator>();
        mediationBinder.Bind<GameRunnerView>().To<GameRunnerMediator>();

        // Other

        injectionBinder.Bind<IInputControl>().ToValue(_input);

    }

    public void LaunchContext()
    {
        Start();
    }

    public void SetBinder(ICrossContextInjectionBinder binder)
    {
        this.injectionBinder = binder;
    }
}
