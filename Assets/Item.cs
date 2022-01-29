using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string currItem;
    [SerializeField] private TMPro.TMP_Text itemUI;

    public string getItem()
    {
        return currItem;
    }

    public void setItem(string item)
    {
        currItem = item;
        itemUI.text = currItem;
    }
}
