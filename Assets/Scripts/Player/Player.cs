using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    [SerializeField] private float walkSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        var inputMove = Input.GetAxis("Horizontal") * Vector2.right + Input.GetAxis("Vertical") * Vector2.up;

        var forwardGroundDir = Vector3.ProjectOnPlane(GetComponent<PlayerLook>().getLookDir(), Vector3.up);
        var sideGroundDir = Vector3.Cross(Vector3.up, forwardGroundDir);

        this.velocity += Physics.gravity * Time.deltaTime;
        this.velocity = new Vector3(0f, this.velocity.y, 0f);
        this.velocity += (inputMove.x * sideGroundDir + inputMove.y * forwardGroundDir).normalized * walkSpeed;

        this.controller.Move(this.velocity * Time.deltaTime);
        if (this.controller.isGrounded) {
            this.velocity.y = 0f;
        }
    }
}
