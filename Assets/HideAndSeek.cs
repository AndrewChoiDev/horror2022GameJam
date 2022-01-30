using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndSeek : MonoBehaviour {

    GameObject player;
    GameObject brother;

    GameObject pointsObject;
    GameObject[] pointsArray;

    // The first three coordinates are positions and the last is a 0 or 1
    // if the brother has been found at the point
    Vector4[] points;
    int currentPointIdx;

    int finds = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        brother = GameObject.Find("Brother");

        pointsObject = GameObject.Find("Points");
        pointsArray = GameObject.FindGameObjectsWithTag("HNS Point");
        points = new Vector4[pointsArray.Length];

        for (int i = 0; i < pointsArray.Length; i++) {
            Transform t = pointsArray[i].GetComponent<Transform>();
            float x = t.transform.position.x;
            float y = t.transform.position.y;
            float z = t.transform.position.z;
            points[i] = new Vector4(x, y, z, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        if (FoundBrother()) {
            finds++;
        }
    }

    bool FoundBrother() {
        Vector3 brotherPosition = brother.transform.position;
        Vector3 playerPosition = player.transform.position;
        return Vector3.Distance(brotherPosition, playerPosition) < 1;
    }
}
