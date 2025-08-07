using UnityEngine;

public class GameState : IState
{
    private GameRunnerView _gameRunnerView;

    
    public void InitializeWithView(GameRunnerView view)
    {
        _gameRunnerView = view;
    }

    public void Load()
    {
        _gameRunnerView.EnableTick();
    }

    public void Unload()
    {
        _gameRunnerView.DisableTick();
    }
}
