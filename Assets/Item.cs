using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //This class manages the equipped item
    private string currItem;
    [SerializeField] private EditText itemUI;

    private void Awake() {
        
    }

    public string getItem()
    {
        return currItem;
    } //This is for other scripts to check what item the user is holding

    public void setItem(string item)
    {
        currItem = item;
        itemUI.setText(item);
    } //This is for picking up item
}
