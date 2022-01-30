using System.Collections;
using System.Collections.Generic;
//using static System.DateTime;
using UnityEngine;

public class SetDate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.DateTime date = System.DateTime.Today;
        this.GetComponent<TMPro.TMP_Text>().text = "01/30/1960 - " +
            date.Month + "/" + date.Day + "/1970";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
