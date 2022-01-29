using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //This script is a component of a pickup
    [SerializeField] private StringGameEvent gameEvent;

    public void pickup()
    {
        gameEvent.Invoke(this.name);
        // item.setItem(this.name);
    }
}
