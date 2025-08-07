using UnityEngine;

public interface IBallSkinsService
{
    void Next();
    void Prev();
    BallElement GetCurrent();
}
