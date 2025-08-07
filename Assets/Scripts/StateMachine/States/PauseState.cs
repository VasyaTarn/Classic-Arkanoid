using UnityEngine;

public class PauseState : IState
{
    [Inject] public PauseScreen PauseScreen { get; private set; }
    [Inject] public StartGameSignal StartGameSignal { get; private set; }
    [Inject] public BallLaunchedSignal BallLaunchedSignal { get; private set; }


    public void Load()
    {
        PauseScreen.UnpauseClicked += Unpause;

        PauseScreen.Show();
        PauseScreen.PlayHintPulse();

        Time.timeScale = 0f;
    }

    public void Unload()
    {
        PauseScreen.StopHintPulse();
        PauseScreen.Hide();

        PauseScreen.UnpauseClicked -= Unpause;

        Time.timeScale = 1f;
    }

    private void Unpause()
    {
        StartGameSignal.Dispatch();

        BallLaunchedSignal.Dispatch();
    }
}
