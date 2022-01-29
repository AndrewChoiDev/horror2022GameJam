using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private PlayerLook playerLook;
    [SerializeField] private Transform origin;
    // Start is called before the first frame update
    void Start()
    {
        playerLook = this.GetComponent<PlayerLook>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycastHit = new RaycastHit();
            //this.GetComponent<Transform>().position
            bool hit = Physics.Raycast(origin.position,
                playerLook.getLookDir(), out raycastHit, 3.0f);
            //using the eye's transform seems to be more consistent than the player's

            if (hit)
            {
                raycastHit.collider.GetComponent<InteractHitbox>()?.invoke();
            }
        }
    }
}
