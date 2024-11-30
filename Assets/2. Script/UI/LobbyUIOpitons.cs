using UnityEngine;

public class LobbyUIOpitons : MonoBehaviour
{
    public void Btn_StartButton()
    {
        SceneController.ChangeScene(SceneController.SceneType.Play);
    }

    public void Btn_QuitButton()
    {
        Application.Quit();
    }

    public void IF_InputField(string input)
    {
        GameManager.Instance.SetName(input);
    }
}
