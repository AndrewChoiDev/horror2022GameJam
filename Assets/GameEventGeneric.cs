using UnityEngine;
using System.Collections.Generic;

public class GameEventGeneric<T> : ScriptableObject {
    private HashSet<IGameEventListenerGeneric<T>> listeners = 
        new HashSet<IGameEventListenerGeneric<T>>();

    public void Invoke(T input) { 
        foreach (var listener in listeners)
            listener.RaiseEvent(input);
    }

    public void Register(IGameEventListenerGeneric<T> listener) => listeners.Add(listener);
    public void Deregister(IGameEventListenerGeneric<T> listener) => listeners.Remove(listener);
}

public interface IGameEventListenerGeneric<T> {
    void RaiseEvent(T input);
}