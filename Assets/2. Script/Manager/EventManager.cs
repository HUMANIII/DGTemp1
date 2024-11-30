using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public enum EventType
    {
        OnClickTab,
    }
}
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

    private Dictionary<Event.EventType, Action> EventDic = new();

    public void AddEvent(Event.EventType eventType, Action action)
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

    public void RemoveEvent(Event.EventType eventType, Action action)
    {
        if (EventDic.ContainsKey(eventType))
        {
            EventDic[eventType] -= action;
        }
    }


    public void DoEvent(Event.EventType eventType)
    {
        EventDic[eventType]?.Invoke();
    }
}
