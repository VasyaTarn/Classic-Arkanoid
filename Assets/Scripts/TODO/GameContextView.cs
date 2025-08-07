using strange.extensions.context.impl;
using strange.extensions.injector.api;
using UnityEngine;

public class GameContextView : MonoBehaviour
{
    [SerializeField] private BaseInputControl _input;
    public BaseInputControl Input => _input;
}
