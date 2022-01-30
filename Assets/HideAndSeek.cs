using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HideAndSeek : MonoBehaviour {

    GameObject player;
    GameObject brother;

    // The first three coordinates are positions and the last is a 0 or 1
    // if the brother has been found at the point
    GameObject[] pointsArray;

    int finds = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        brother = GameObject.Find("brother");

        pointsArray = GameObject.FindGameObjectsWithTag("HNS Point");
        ShufflePoints();
        
        MoveBrother();
    }

    // Update is called once per frame
    void Update() {
        if (FoundBrother()) {
            Debug.Log(finds + " " + pointsArray.Length);
            if (finds != pointsArray.Length) {
                finds++;
                MoveBrother();

                if (finds == pointsArray.Length - 1) {
                    if (pointsArray[finds].GetComponent<ToNextScene>() == null) {
                        pointsArray[finds].AddComponent<ToNextScene>();
                        
                        pointsArray[finds].AddComponent<BoxCollider>();
                        pointsArray[finds].GetComponent<BoxCollider>().isTrigger = true;
                    }
                }
            }            
        }
    }

    bool FoundBrother() {
        Vector3 brotherPosition = brother.transform.position;
        Vector3 playerPosition = player.transform.position;
        return Vector3.Distance(brotherPosition, playerPosition) < 1;
    }

    void MoveBrother() {
        if (finds != pointsArray.Length) {
            Debug.Log("brother moved");
            brother.transform.position = pointsArray[finds].transform.position + new Vector3(0, 1, 0);
        }
    }

    void ShufflePoints() {
        // Moves things around
        for (int i = pointsArray.Length - 1; i > 0; i--) {
            int j = Random.Range(0, i);
            Vector3 temp = pointsArray[i].transform.position;
            pointsArray[i].transform.position = pointsArray[j].transform.position; 
            pointsArray[j].transform.position = temp;
        }
    }
}
