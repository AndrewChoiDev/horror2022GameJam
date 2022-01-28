using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditText : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.GetComponent<TMPro.TextMeshPro>();
        textMesh.text = "New Text";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
