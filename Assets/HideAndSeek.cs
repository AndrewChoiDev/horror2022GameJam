using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndSeek : MonoBehaviour {

    GameObject player;
    GameObject brother;

    // The first three coordinates are positions and the last is a 0 or 1
    // if the brother has been found at the point
    List<Vector3> pointsList;
    GameObject[] pointsArray;

    int currentPointIndex;
    int finds = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        brother = GameObject.Find("Brother");

        pointsList = new List<Vector3>();
        pointsArray = GameObject.FindGameObjectsWithTag("HNS Point");
        
        for (int i = 0; i < pointsArray.Length; i++) {
            Transform t = pointsArray[i].GetComponent<Transform>();
            float x = t.transform.position.x;
            float y = t.transform.position.y;
            float z = t.transform.position.z;
            pointsList[i] = new Vector3(x, y, z);
        }

        currentPointIndex = Random.Range(0, pointsArray.Length);
        brother.transform.position = pointsList[currentPointIndex];
    }

    // Update is called once per frame
    void Update() {
        if (FoundBrother()) {
            pointsList.RemoveAt(currentPointIndex);
            currentPointIndex = Random.Range(0, pointsList.Count);
            brother.transform.position = pointsList[currentPointIndex];
            finds++;
        }
        if (finds + 1 == pointsArray.Length) {
            // Find the remaining point GameObject and attach To Next Scene
            for (int i = 0; i < pointsArray.Length; i++) {
                bool sameX = pointsArray[i].transform.position.x == pointsList[0].x;
                bool sameY = pointsArray[i].transform.position.y == pointsList[0].y;
                bool sameZ = pointsArray[i].transform.position.z == pointsList[0].z;
                if (sameX && sameY && sameZ) {
                    pointsArray[i].AddComponent<ToNextScene>();
                    break;
                }
            }
        }
    }

    bool FoundBrother() {
        Vector3 brotherPosition = brother.transform.position;
        Vector3 playerPosition = player.transform.position;
        return Vector3.Distance(brotherPosition, playerPosition) < 1;
    }
}
