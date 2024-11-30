using UnityEngine;

public class EndingButtonOptions : MonoBehaviour
{
    public void Btn_TitleButton()
    {
        SceneController.ChangeScene(SceneController.SceneType.Lobby);
    }

    public void Btn_RestartButton()
    {
        SceneController.ChangeScene(SceneController.SceneType.Play);
    }
}
