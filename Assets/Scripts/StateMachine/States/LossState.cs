using UnityEngine;

public class LossState : IState
{
    [Inject] public LossScreen LossScreen { get; private set; }
    [Inject] public ExitGameSignal ExitGameSignal { get; private set; }
    [Inject] public ResetGameSignal ResetGameSignal { get; private set; }
    [Inject] public GameModel GameModel { get; private set; }


    public void Load()
    {
        LossScreen.RepearClicked += OnRepeat;
        LossScreen.ExitClicked += OnExit;

        LossScreen.ChangeScoreAmount(GameModel.Score);

        Time.timeScale = 0f;

        LossScreen.Show();
    }

    public void Unload()
    {
        LossScreen.Hide();

        LossScreen.RepearClicked -= OnRepeat;
        LossScreen.ExitClicked -= OnExit;
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
