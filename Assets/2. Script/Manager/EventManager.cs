using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public enum EventType
    {
        OnClickTab,
        OnStartGame,
        OnEndGame,
    }

    private static Dictionary<EventType, Action> EventDic = new();

    public static void AddEvent(EventType eventType, Action action)
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

    public static void RemoveEvent(EventType eventType, Action action)
    {
        if (EventDic.ContainsKey(eventType))
        {
            EventDic[eventType] -= action;
        }
    }


    public static void DoEvent(EventType eventType)
    {
        DebugPanel.LogMessage($"DoEvent : {eventType}");
        EventDic[eventType]?.Invoke();
    }
}
