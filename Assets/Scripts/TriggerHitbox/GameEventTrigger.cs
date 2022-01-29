using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;

    public void invoke()
    {
        unityEvent?.Invoke();
    }

    public void printSth()
    {
        Debug.Log("Debug");
    }
}
