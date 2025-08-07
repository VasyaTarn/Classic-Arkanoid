using System;
using strange.extensions.mediation.impl;
using UnityEngine;

public class FixedGameRunnderView : View
{
    public event Action OnFixedTick;

    private bool _isRunning;

    public void EnableTick() => _isRunning = true;
    public void DisableTick() => _isRunning = false;

    private void FixedUpdate()
    {
        if (_isRunning)
        {
            OnFixedTick?.Invoke();
        }
    }
}
