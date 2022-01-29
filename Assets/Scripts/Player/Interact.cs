using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private PlayerLook playerLook;
    // Start is called before the first frame update
    void Start()
    {
        playerLook = this.GetComponent<PlayerLook>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key is clicked");
            RaycastHit raycastHit = new RaycastHit();
            bool hit = Physics.Raycast(this.GetComponent<Transform>().position,
                playerLook.getLookDir(), out raycastHit, 3.0f);

            if (hit)
            {
                raycastHit.collider.GetComponentInParent<InteractHitbox>().invoke();
            }
        }
    }
}
