using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemUsed : MonoBehaviour
{
    [SerializeField] string item;
    [SerializeField] Item itemController;
    [SerializeField] UnityEvent unityEvent;
    
    public void checkItem()
    {
        if (string.Equals(this.item, itemController.getItem())) 
        {
            Debug.Log("Cereal used on bowl");
            itemController.setItem("");
            unityEvent?.Invoke();
        }
    }
}
