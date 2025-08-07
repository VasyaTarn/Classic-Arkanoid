using UnityEngine;

public class MainContext : SignalContext
{
    private readonly UIManager _uiManager;
    private readonly IInputControl _input;
    private readonly BricksService _brickService;
    private readonly BallsConfig _ballsConfig;


    public MainContext(MonoBehaviour contextView, UIManager uiManager, IInputControl input, BricksService brickService, BallsConfig ballsConfig) : base(contextView)
    {
        _uiManager = uiManager;
        _input = input;
        _brickService = brickService;
        _ballsConfig = ballsConfig;
    }

    // TODO: Разделение контекстов (GameContext, MenuContext) запланировано и частично реализовано в папке TODO,
    // но пока используется один основной контекст для стабильности и простоты.

    protected override void mapBindings()
    {
        base.mapBindings();

        // General

        injectionBinder.Bind<IStateMachine>().To<StateMachine>().ToSingleton();

        // Services

        injectionBinder.Bind<IBallService>().To<BallService>().ToSingleton();
        injectionBinder.Bind<BricksService>().ToValue(_brickService).ToSingleton();
        injectionBinder.Bind<IBallSkinsService>().To<BallSkinsService>().ToSingleton();

        // Models

        injectionBinder.Bind<PlatformModel>().ToSingleton();
        injectionBinder.Bind<BallModel>().ToSingleton();
        injectionBinder.Bind<BallSkinsModel>().ToSingleton();
        injectionBinder.Bind<GameModel>().ToSingleton();

        // Signals

        injectionBinder.Bind<AppStartSignal>().ToSingleton();

        injectionBinder.Bind<MovePlatformSignal>().ToSingleton();
        injectionBinder.Bind<PlatformTickSignal>().ToSingleton();

        injectionBinder.Bind<StartGameSignal>().ToSingleton();
        injectionBinder.Bind<OpenPauseSignal>().ToSingleton();

        injectionBinder.Bind<BallLaunchedSignal>().ToSingleton();
        injectionBinder.Bind<BallOutOfBoundsSignal>().ToSingleton();

        injectionBinder.Bind<DestroyBrickSignal>().ToSingleton();

        injectionBinder.Bind<OpenLossScreenSignal>().ToSingleton();
        injectionBinder.Bind<OpenCompleteScreenSignal>().ToSingleton();

        injectionBinder.Bind<ReloadSceneSignal>().ToSingleton();
        injectionBinder.Bind<ExitGameSignal>().ToSingleton();

        injectionBinder.Bind<ResetGameSignal>().ToSingleton();
        injectionBinder.Bind<ResetPlatformPositionSignal>().ToSingleton();

        injectionBinder.Bind<BallSkinChangedSignal>().ToSingleton();

        // Commands

        commandBinder.Bind<AppStartSignal>().To<OpenMenuCommand>();

        commandBinder.Bind<OpenMenuSignal>().To<OpenMenuCommand>();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
        commandBinder.Bind<OpenPauseSignal>().To<OpenPauseCommand>();
        commandBinder.Bind<OpenLossScreenSignal>().To<OpenLossScreenCommand>();
        commandBinder.Bind<OpenCompleteScreenSignal>().To<OpenCompleteScreenCommand>();

        commandBinder.Bind<MovePlatformSignal>().To<MovePlatformCommand>();

        commandBinder.Bind<BallLaunchedSignal>().To<BallLaunchedCommand>();
        commandBinder.Bind<BallOutOfBoundsSignal>().To<BallOutOfBoundsCommand>();

        commandBinder.Bind<DestroyBrickSignal>().To<DestroyBrickCommand>();

        commandBinder.Bind<ReloadSceneSignal>().To<ReloadSceneCommand>();
        commandBinder.Bind<ExitGameSignal>().To<ExitGameCommand>();

        commandBinder.Bind<ResetGameSignal>().To<ResetGameCommand>();

        // Mediation

        mediationBinder.Bind<PlatformView>().To<PlatformMediator>();
        mediationBinder.Bind<GameRunnerView>().To<GameRunnerMediator>();
        mediationBinder.Bind<FixedGameRunnderView>().To<FixedGameRunnderMediator>();
        mediationBinder.Bind<BallView>().To<BallMediator>();

        // States

        injectionBinder.Bind<MenuState>().To<MenuState>().ToSingleton();
        injectionBinder.Bind<GameState>().To<GameState>().ToSingleton();
        injectionBinder.Bind<PauseState>().To<PauseState>().ToSingleton();
        injectionBinder.Bind<LossState>().To<LossState>().ToSingleton();
        injectionBinder.Bind<CompleteState>().To<CompleteState>().ToSingleton();

        // Views

        injectionBinder.Bind<MenuScreen>().ToValue(_uiManager.MenuScreen);
        injectionBinder.Bind<PauseScreen>().ToValue(_uiManager.PauseScreen);
        injectionBinder.Bind<LossScreen>().ToValue(_uiManager.LossScreen);
        injectionBinder.Bind<CompleteScreen>().ToValue(_uiManager.CompleteScreen);


        // Other

        injectionBinder.Bind<IInputControl>().ToValue(_input);
        injectionBinder.Bind<BallsConfig>().ToValue(_ballsConfig);

    }

    public override void Launch()
    {
        base.Launch();

        injectionBinder.GetInstance<AppStartSignal>().Dispatch();
    }
}
