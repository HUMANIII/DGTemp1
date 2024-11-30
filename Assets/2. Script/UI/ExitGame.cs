using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitGame : MonoBehaviour
{
    [SerializeField] private Button button;


    private void Awake()
    {
        button ??= GetComponent<Button>();
        button.onClick.AddListener(ExitPlay);
    }

    public void ExitPlay()
    {
        SceneController.ChangeScene(SceneController.SceneType.Ending);
    }
}
