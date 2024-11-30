using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class EventManager
{
    public enum EventType
    {
        OnClickTab,
    }

    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            instance ??= new EventManager();
            return instance;
        }
    }

    private Dictionary<EventType, Action> EventDic = new();

    public void AddEvent(EventType eventType, Action action)
    {
        if (EventDic.ContainsKey(eventType))
        {
            EventDic[eventType] += action;
        }
        else
        {
            EventDic.Add(eventType, action);
        }
    }

    public void RemoveEvent(EventType eventType, Action action)
    {
        if (EventDic.ContainsKey(eventType))
        {
            EventDic[eventType] -= action;
        }
    }


    public void DoEvent(EventType eventType)
    {
        EventDic[eventType]?.Invoke();
    }
}
