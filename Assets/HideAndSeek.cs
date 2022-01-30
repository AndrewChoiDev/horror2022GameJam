using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndSeek : MonoBehaviour {

    GameObject player;
    GameObject brother;

    GameObject[] pointsArray;

    // The first three coordinates are positions and the last is a 0 or 1
    // if the brother has been found at the point
    List<Vector3> points;
    int currentPointIndex;

    int finds = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        brother = GameObject.Find("Brother");
        points = new List<Vector3>();

        GameObject pointsObject = GameObject.Find("Points");
        pointsArray = GameObject.FindGameObjectsWithTag("HNS Point");
        
        for (int i = 0; i < pointsArray.Length; i++) {
            Transform t = pointsArray[i].GetComponent<Transform>();
            float x = t.transform.position.x;
            float y = t.transform.position.y;
            float z = t.transform.position.z;
            points[i] = new Vector3(x, y, z);
        }

        currentPointIndex = Random.Range(0, pointsArray.Length);
    }

    // Update is called once per frame
    void Update() {
        if (FoundBrother()) {
            points.RemoveAt(currentPointIndex);
            currentPointIndex = Random.Range(0, points.Count);
            brother.transform.position = points[currentPointIndex];
            finds++;
        }
        if (finds == pointsArray.Length) {
            
        }
    }

    bool FoundBrother() {
        Vector3 brotherPosition = brother.transform.position;
        Vector3 playerPosition = player.transform.position;
        return Vector3.Distance(brotherPosition, playerPosition) < 1;
    }
}
