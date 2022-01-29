using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractHitbox : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;

    public void invoke()
    {
        unityEvent?.Invoke();
    }
}
