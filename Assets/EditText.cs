using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void editText(string text)
    {
        textMesh.text = text;
    }
}
