using UnityEngine;

public class BallSkinsService : IBallSkinsService
{
    [Inject] public BallSkinsModel Model { get; set; }
    [Inject] public BallsConfig Config { get; set; }
    [Inject] public BallSkinChangedSignal BallSkinChanged { get; set; }


    public void Next()
    {
        Model.SetIndex((Model.CurrentIndex + 1) % Config.Elements.Length);
        BallSkinChanged.Dispatch();
    }

    public void Prev()
    {
        Model.SetIndex((Model.CurrentIndex - 1 + Config.Elements.Length) % Config.Elements.Length);
        BallSkinChanged.Dispatch();
    }

    public BallElement GetCurrent()
    {
        return Config.Elements[Model.CurrentIndex];
    }
}
