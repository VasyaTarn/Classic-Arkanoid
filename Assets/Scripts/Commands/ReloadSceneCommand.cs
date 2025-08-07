using strange.extensions.command.impl;
using UnityEngine.SceneManagement;

public class ReloadSceneCommand : Command
{
    [Inject] public string SceneName { get; private set; }


    public override void Execute()
    {
        SceneManager.LoadScene(SceneName);
    }
}
