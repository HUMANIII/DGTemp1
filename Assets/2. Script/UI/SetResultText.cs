using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SetResultText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;

    private void Start()
    {
        resultText.text = GameManager.Instance.GetResultText();
    }
}
