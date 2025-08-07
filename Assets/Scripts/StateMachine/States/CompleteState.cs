using UnityEngine;

public class CompleteState : IState
{
    [Inject] public CompleteScreen CompleteScreen { get; private set; }
    [Inject] public ExitGameSignal ExitGameSignal { get; private set; }
    [Inject] public ResetGameSignal ResetGameSignal { get; private set; }
    [Inject] public GameModel GameModel { get; private set; }


    public void Load()
    {
        CompleteScreen.RepearClicked += OnRepeat;
        CompleteScreen.ExitClicked += OnExit;

        CompleteScreen.ChangeScoreAmount(GameModel.Score);

        Time.timeScale = 0f;

        CompleteScreen.Show();
    }

    public void Unload()
    {
        CompleteScreen.Hide();

        CompleteScreen.RepearClicked -= OnRepeat;
        CompleteScreen.ExitClicked -= OnExit;
    }

    private void OnRepeat()
    {
        ResetGameSignal.Dispatch();
    }

    private void OnExit()
    {
        ExitGameSignal.Dispatch();
    }
}
