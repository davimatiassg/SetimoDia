using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventSystem : MonoBehaviour
{

    private static CardEventSystem instance;

    private Dictionary<string, Action<CardEventCircumstances>> events;

    public static CardEventSystem getInstance()
    {
        return instance;
    }

    public CardEventSystem()
    {
        if(CardEventSystem.instance != this) {Destroy(this.gameObject);}
        if(CardEventSystem.instance == null) {
            CardEventSystem.instance = this; 
        }

        CardEventSystem.instance.events = new Dictionary<string, Action<CardEventCircumstances>>();
        
    }

    public static void AddEvent(string eventName, Action<CardEventCircumstances>? method )
    {
        if(method == null){ return; }
        if(!instance.events.ContainsKey(eventName))
        {   
            instance.events.Add(eventName, method);
            return;
        }
        instance.events[eventName] += method;
    }

    public static void RemoveEvent(string eventName, Action<CardEventCircumstances>? method )
    {
        if(method == null){ return; }
        if(! instance.events.ContainsKey(eventName)) { return; }
        instance.events[eventName] -= method;
    }

    public static void InvokeEvent(string eventName, CardEventCircumstances circumstances)
    {
        instance.events[eventName](circumstances);
    }
}
