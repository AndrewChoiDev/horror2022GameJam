using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditText : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text textMesh;

    // Start is called before the first frame update
    void Awake()
    {
    }

    public void setText(string text)
    {
        textMesh.text = text;
    }

}
