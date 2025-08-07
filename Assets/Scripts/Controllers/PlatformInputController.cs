using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlatformInputController : BaseInputControl
{
    private GameControls _controls;


    private void Awake()
    {
        _controls = new GameControls();

        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Gameplay.Move.performed += OnMove;
        _controls.Gameplay.Move.canceled += _ => Direction = 0;
    }

    private void OnDisable()
    {
        _controls.Gameplay.Move.performed -= OnMove;
        _controls.Gameplay.Move.canceled -= _ => Direction = 0;
        _controls.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 pos = context.ReadValue<Vector2>();
        float half = Screen.width / 2f;
        Direction = pos.x < half ? -1f : 1f;
    }
}
