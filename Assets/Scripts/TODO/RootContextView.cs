using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.injector.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RootContextView : ContextView
{
    [SerializeField] private MenuContextView _menuContextView;
    [SerializeField] private GameContextView _gameContextView;

    private RootContext _rootContext;

    private void Awake()
    {
        var contexts = new Dictionary<ContextType, ICustomContext>
        {
            { ContextType.MenuContext, new MenuContext(this, _menuContextView.UIManager, null) },
            { ContextType.GameContext, new GameContext(this, _gameContextView.Input, null) }
        };

        _rootContext = new RootContext(this, contexts);
        context = _rootContext;

        var binder = (ICrossContextInjectionBinder)_rootContext.injectionBinder;

        contexts[ContextType.MenuContext].SetBinder(binder);
        contexts[ContextType.GameContext].SetBinder(binder);

        _rootContext.Start();
    }
}
