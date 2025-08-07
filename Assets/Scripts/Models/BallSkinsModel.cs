using UnityEngine;

public class BallSkinsModel
{
    public int CurrentIndex { get; private set; }

    public void SetIndex(int index)
    {
        CurrentIndex = index;
    }
}
