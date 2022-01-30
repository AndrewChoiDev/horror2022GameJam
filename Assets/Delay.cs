using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject background;
    [SerializeField] private float delay;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            image.SetActive(true);
            text.SetActive(true);
            background.SetActive(false);
        }
    }
}
