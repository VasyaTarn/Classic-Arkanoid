using strange.extensions.command.impl;
using UnityEngine;

public class DestroyBrickCommand : Command
{
    [Inject] public GameObject Brick { get; private set; }
    [Inject] public GameModel GameModel { get; private set; }
    [Inject] public BricksService BricksService { get; private set; }
    [Inject] public OpenCompleteScreenSignal OpenCompleteScreenSignal { get; private set; }


    public override void Execute()
    {
        Brick.SetActive(false);

        GameModel.Score++;

        if(!BricksService.HasAnyActiveChild())
        {
            OpenCompleteScreenSignal.Dispatch();
        }
    }
}
