using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //This script is a component of a pickup
    [SerializeField] private Item item;

    public void pickup()
    {
        item.setItem(this.name);
    }
}
