using System.Collections.Generic;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.injector.api;
using UnityEngine;

public class RootContext : SignalContext
{
    private readonly Dictionary<ContextType, ICustomContext> _contexts;


    public RootContext(MonoBehaviour contextView, Dictionary<ContextType, ICustomContext> contexts)
        : base(contextView)
    {
        _contexts = contexts;
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Unbind<IEventDispatcher>();

        injectionBinder.Bind<IEventDispatcher>()
            .To<EventDispatcher>()
            .ToSingleton()
            .CrossContext()
            .Named(ContextKeys.CROSS_CONTEXT_DISPATCHER);
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        // General

        injectionBinder.Bind<IStateMachine>().To<StateMachine>().ToSingleton();

        // Signals

        injectionBinder.Bind<AppStartSignal>().ToSingleton();

        // Commands

        commandBinder.Bind<AppStartSignal>().To<OpenMenuCommand>().Once();

        // States

        injectionBinder.Bind<MenuState>().To<MenuState>();
        injectionBinder.Bind<GameState>().To<GameState>();
    }

    public void LaunchMenu()
    {
        _contexts[ContextType.MenuContext].LaunchContext();
    }

    public void LaunchGame()
    {
        _contexts[ContextType.GameContext].LaunchContext();
    }
}
