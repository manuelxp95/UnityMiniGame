using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager Instance;

    private Dictionary<string, Action> eventListeners = new Dictionary<string, Action>();


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Subscribe(string eventName, Action listener)
    {
        if (!eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName] = null;
        }
        eventListeners[eventName] += listener;
    }

    public void Unsubscribe(string eventName, Action listener)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName] -= listener;
        }
    }

    public void TriggerEvent(string eventName)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName]?.Invoke();
        }
    }
}