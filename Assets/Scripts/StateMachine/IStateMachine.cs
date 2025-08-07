using UnityEngine;

public interface IStateMachine
{
    IState LastState { get; }

    void Load(IState state);
    void Unload(bool loadPrev);

    public void UnloadActiveStates();
}
