using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //This class manages the equipped item
    private string currItem;
    [SerializeField] private TMPro.TMP_Text itemUI;

    public string getItem()
    {
        return currItem;
    } //This is for other scripts to check what item the user is holding

    public void setItem(string item)
    {
        currItem = item;
        itemUI.text = currItem;
    } //This is for picking up item

    void Start()
    {
        itemUI.text = "";
    }
}
