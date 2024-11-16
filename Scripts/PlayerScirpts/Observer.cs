using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    static Dictionary<string, List<Action>> doEvent = new Dictionary<string, List<Action>>();
    
    public static void AddObserver(string name, Action action)
    {
        if (!doEvent.ContainsKey(name))
        {
            doEvent.Add(name, new List<Action>());
        }
        doEvent[name].Add(action);
    }
    public static void RemoveObserver(string name, Action action)
    {
        if (!doEvent.ContainsKey(name))
            return;
        doEvent[name].Remove(action);
    }
    public static void Notify(string name)
    {
        if (!doEvent.ContainsKey(name))
            return;
        foreach (Action action in doEvent[name])
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError("Error on Invoke" + e);
            }
        }
    }
}
