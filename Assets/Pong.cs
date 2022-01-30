using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour
{
    [SerializeField] private GameEvent returnControl;
    [SerializeField] private GameEvent highScore;
    [SerializeField] private Vector2 initVel;
    private Vector2 vel;

    [SerializeField] private BoxCollider2D boxRebound;
    [SerializeField] private BoxCollider2D paddle;
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform initTransform;

    private bool gameIsStarted = false;
    private int counter = 0;
    [SerializeField] private EditText editText;

    private void Start() {
        vel = initVel;
    }

    public void startGame() {
        gameIsStarted = true;
        vel = initVel;
        transform.position = initTransform.position;
        counter = 0;
    }

    private bool inPaddle() {
        if (transform.position.y < paddle.bounds.max.y && transform.position.y > paddle.bounds.min.y) {
            return true;
        }
        return false;
    }

    private void Update() {
        transform.position += new Vector3(vel.x, vel.y, 0f) * Time.deltaTime;

        var boundsMax = boxRebound.bounds.max;
        var boundsMin = boxRebound.bounds.min;

        if (transform.position.x < paddle.bounds.max.x 
            && inPaddle() && vel.x < 0f) {
            vel.x = -vel.x;
            transform.position = new Vector3(paddle.bounds.max.x, transform.position.y, transform.position.z);
            
        }
        if (transform.position.x < boundsMin.x) {
            vel = initVel;
            transform.position = initTransform.position;
        }
        if (transform.position.x > boundsMax.x) {
            vel.x = -vel.x;
            transform.position = new Vector3(boundsMax.x, transform.position.y, transform.position.z);
            counter += 1;
        }
        
        if (transform.position.y < boundsMin.y) {
            vel.y = -vel.y;
            transform.position = new Vector3(transform.position.x, boundsMin.y, transform.position.z);
        }
        if (transform.position.y > boundsMax.y) {
            vel.y = -vel.y;
            transform.position = new Vector3(transform.position.x, boundsMax.y, transform.position.z);
        }

        paddle.transform.position += Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * 0.5f;
        var clampedY = Mathf.Clamp(paddle.transform.position.y, boundsMin.y, boundsMax.y);
        paddle.transform.position = new Vector3(paddle.transform.position.x, 
            clampedY, paddle.transform.position.z);
        

        if (Input.GetKeyDown(KeyCode.E)) {
            gameIsStarted = false;
            returnControl.Invoke();
        }

        if (counter > 6) {
            highScore.Invoke();
        }

        editText.setText(this.counter.ToString());
    }
}
