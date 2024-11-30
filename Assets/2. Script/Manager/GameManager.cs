using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();                
            }
            return instance;
        }
    }

    private string PlayerName;
    private float StartTime;
    private float EndTime;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        EventManager.AddEvent(EventManager.EventType.OnStartGame, StartGame);
        EventManager.AddEvent(EventManager.EventType.OnEndGame, EndGame);
    }

    private void StartGame()
    {
        StartTime = Time.time;
    }
    public void EndGame()
    {
        EndTime = Time.time;
    }
    public void GetName(string name)
    {
        PlayerName = name;
        DebugPanel.LogMessage("PlayerName : " + PlayerName);
    }

    public string GetResultText()
    {
        return $"PlayerName : {PlayerName} \n PlayTime : {(int)(EndTime - StartTime)} seconds";
    }

}
