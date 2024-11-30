using System;
using UnityEngine;

public class EventManager
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            instance ??= new EventManager();
            return instance;
        }
    }

    public event Action OnClickTab;

    public void ClickTab()
    {
        OnClickTab?.Invoke();
    }
}
