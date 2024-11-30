using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.DoEvent(EventManager.EventType.OnStartGame);
    }

    private void OnDestroy()
    {
        EventManager.DoEvent(EventManager.EventType.OnEndGame);
    }
}
