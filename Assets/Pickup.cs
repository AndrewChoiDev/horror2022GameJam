using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Item item;
    public void pickup()
    {
        item.setItem(this.name);
    }
}
