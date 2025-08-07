using strange.extensions.command.impl;
using UnityEngine;

public class ExitGameCommand : Command
{
    public override void Execute()
    {
        Application.Quit();
    }
}
