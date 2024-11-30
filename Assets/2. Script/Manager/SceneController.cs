using UnityEngine;

public class SceneController
{
    public enum SceneType
    {
        Lobby,
        Play,
        Ending
    }

    public static void ChangeScene(SceneType sceneType)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneType.ToString());
    }
}
