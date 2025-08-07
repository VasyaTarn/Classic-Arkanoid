using strange.extensions.context.impl;
using UnityEngine;

public class MainContextView : ContextView
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private BaseInputControl _inputControl;
    [SerializeField] private BricksService _brickService;
    [SerializeField] private BallsConfig _ballsConfig;


    private void Awake()
    {
        var context = new MainContext(this, _uiManager, _inputControl, _brickService, _ballsConfig);

        context.Start();
    }
}
