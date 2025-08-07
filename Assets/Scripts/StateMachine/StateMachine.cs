using System.Collections.Generic;
using UnityEngine;

public class StateMachine : IStateMachine
{
    private readonly Stack<IState> Stack = new();

    private IState _currentState;

    public IState LastState
    {
        get
        {
            if(Stack.Count == 0)
            {
                return null;
            }

            return Stack.Peek();
        }
    }

    public void Load(IState state)
    {
        while(Stack.Count != 0)
        {
            var item = Stack.Pop();
            item.Unload();
        }

        _currentState = state;

        Stack.Push(_currentState);
        _currentState.Load();
    }

    public void Unload(bool loadPrev)
    {
        var state = Stack.Pop();
        state.Unload();

        if(_currentState == state)
        {
            _currentState = null;
        }

        if(loadPrev && LastState != null)
        {
            LastState.Load();
        }
    }

    public void UnloadActiveStates()
    {
        foreach(var state in Stack)
        {
            state.Unload();
        }
    }
}
