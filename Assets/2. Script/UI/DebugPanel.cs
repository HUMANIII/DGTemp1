using UnityEngine;
using TMPro;
using System;
using System.Text;

public class DebugPanel : MonoBehaviour
{
    private static DebugPanel instance;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int MaxLine = 10;
    private string[] strings;
    private int index = 0;
    private StringBuilder sb = new();

    private void Awake()
    {
        strings = new string[MaxLine];
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void LogMessage(string message)
    {
        instance.Log(message);
    }

    private void Log(string message)
    {
        strings[index] = message;
        index = (index + 1) % MaxLine;
        UpdateText();
    }

    private void UpdateText()
    {
        sb.Clear();
        for (int i = 0; i < MaxLine; i++)
        {
            int currentIndex = (index + i) % MaxLine;
            if (strings[currentIndex] != null)
            {
                sb.AppendLine(strings[currentIndex]);
            }
        }
        text.text = sb.ToString();
    }
}
