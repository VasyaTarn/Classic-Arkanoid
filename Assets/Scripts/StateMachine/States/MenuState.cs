
public class MenuState : IState
{
    [Inject] public MenuScreen MenuScreen { get; private set; }
    [Inject] public OpenPauseSignal OpenPauseSignal { get; private set; }
    [Inject] public IBallSkinsService BallSkinService { get; set; }
    [Inject] public BallSkinChangedSignal BallSkinChangedSignal { get; set; }



    public void Load()
    {
        MenuScreen.ChooseClicked += OnChooseBall;

        MenuScreen.LeftButton.onClick.AddListener(BallSkinService.Prev);
        MenuScreen.RightButton.onClick.AddListener(BallSkinService.Next);

        BallSkinChangedSignal.AddListener(UpdateSkin);

        UpdateSkin();

        MenuScreen.PlayLightPulse();

        MenuScreen.Show();
    }

    public void Unload()
    {
        MenuScreen.Hide();

        MenuScreen.StopLightPulse();

        MenuScreen.LeftButton.onClick.RemoveListener(BallSkinService.Prev);
        MenuScreen.RightButton.onClick.RemoveListener(BallSkinService.Next);
        BallSkinChangedSignal.RemoveListener(UpdateSkin);

        MenuScreen.ChooseClicked -= OnChooseBall;
    }

    private void OnChooseBall()
    {
        OpenPauseSignal.Dispatch();
    }

    private void UpdateSkin()
    {
        var element = BallSkinService.GetCurrent();
        MenuScreen.SetSkin(element);
    }
}
