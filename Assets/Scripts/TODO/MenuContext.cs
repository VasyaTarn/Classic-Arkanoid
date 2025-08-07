using strange.extensions.injector.api;
using UnityEngine;

public class MenuContext : SignalContext, ICustomContext
{
    private readonly UIManager _uiManager;


    public MenuContext(MonoBehaviour contextView, UIManager uiManager, ICrossContextInjectionBinder rootBinder) : base(contextView)
    {
        _uiManager = uiManager;

        this.injectionBinder = rootBinder;
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        // Commands

        commandBinder.Bind<OpenMenuSignal>().To<OpenMenuCommand>();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();

        // Views

        injectionBinder.Bind<MenuScreen>().ToValue(_uiManager.MenuScreen);
    }

    public override void Launch()
    {
        base.Launch();

        injectionBinder.GetInstance<AppStartSignal>().Dispatch();
    }

    public void SetBinder(ICrossContextInjectionBinder binder)
    {
        this.injectionBinder = binder;
    }

    public void LaunchContext()
    {
        Start();
    }
}
           