using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.command.api;
using strange.extensions.command.impl;

using UnityEngine;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class SignalContext : MVCSContext
{
    public SignalContext(MonoBehaviour contextView)
        : base(contextView, ContextStartupFlags.MANUAL_MAPPING)
    {

    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();

        injectionBinder.Unbind<IEventDispatcher>();
        injectionBinder.Bind<IEventDispatcher>()
            .To<EventDispatcher>()
            .ToSingleton()
            .CrossContext()
            .Named(ContextKeys.CROSS_CONTEXT_DISPATCHER);
    }

    public override void Launch()
    {
        base.Launch();
    }

    protected override void mapBindings()
    {
        base.mapBindings();
    }
}
