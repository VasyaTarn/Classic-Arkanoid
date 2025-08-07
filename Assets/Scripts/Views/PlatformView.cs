using strange.extensions.mediation.impl;
using UnityEngine;

public class PlatformView : View
{
    public void SetPositionX(float x)
    {
        var pos = transform.position;
        pos.x = x;
        transform.position = pos;
    }
}
