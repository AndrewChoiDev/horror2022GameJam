using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.name, "Player"))
        {
            string scene = string.Copy(SceneManager.GetActiveScene().name);

            int sceneNum = (int)char.GetNumericValue(scene[4]) + 1;

            SceneManager.LoadSceneAsync("Day " + sceneNum);
        }
        
    }
}
