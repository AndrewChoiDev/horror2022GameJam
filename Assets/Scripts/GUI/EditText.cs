using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditText : MonoBehaviour
{
    private TMPro.TMP_Text textMesh;

    // Start is called before the first frame update
    void Awake()
    {
        textMesh = this.GetComponent<TMPro.TMP_Text>();
    }

    public void setText(string text)
    {
        textMesh.text = text;
    }

    public void setText()
    {
        textMesh.text = "";
    }
}
