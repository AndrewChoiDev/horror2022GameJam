using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float lookSpeed = 1f;

    [Range(0, 359.99f)]
    [SerializeField]
    private float angleA;
    private float angleB;
    private Vector2 lookAngles {get {return new Vector2(angleA, angleB);} set {angleA = value.x; angleB = value.y;}}

    [SerializeField] Transform[] pitchRotators;

    private Vector2 getLookAnglesRad() {
        return new Vector2(lookAngles.x * Mathf.Deg2Rad, lookAngles.y * Mathf.Deg2Rad);
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    public Vector3 getLookDir() {
        var lookAnglesRad = getLookAnglesRad();
        return new Vector3(
                Mathf.Cos(lookAnglesRad.y) * Mathf.Sin(lookAnglesRad.x),
                Mathf.Sin(lookAnglesRad.y), 
                Mathf.Cos(lookAnglesRad.x) * Mathf.Cos(lookAnglesRad.y)
                );
    }

    // Update is called once per frame
    void Update()
    {
        var inputLook = Input.GetAxis("Mouse X") * Vector2.right + Input.GetAxis("Mouse Y") * Vector2.up;
        var newAngles = lookAngles + (inputLook * lookSpeed);
        newAngles.x = (newAngles.x + 360f) % 360f;
        var angleLimit = 89f;
        newAngles.y = Mathf.Clamp(newAngles.y, -angleLimit, angleLimit);

        this.lookAngles = newAngles;

        transform.eulerAngles = Vector2.up * lookAngles.x;

        // var pitchRotation = Quaternion.Euler(-lookAngles.y, 0, 0);
        foreach (var pr in pitchRotators) {
            pr.localRotation = Quaternion.Euler(-lookAngles.y, 
                pr.localEulerAngles.y, pr.localEulerAngles.z);
        }       

    }
}
