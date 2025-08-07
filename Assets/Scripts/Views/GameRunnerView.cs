using System;
using strange.extensions.mediation.impl;
using UnityEngine;

public class GameRunnerView : View
{
    public event Action OnTick;

    private bool _isRunning;
    
    public void EnableTick() => _isRunning = true;
    public void DisableTick() => _isRunning = false;

    private void Update()
    {
        if (_isRunning)
        {
            OnTick?.Invoke();
        }
    }
}
