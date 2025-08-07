using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.injector.impl;
using UnityEngine;

public class MenuContextView : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    public UIManager UIManager => _uiManager;
}
