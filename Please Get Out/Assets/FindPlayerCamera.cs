using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerCamera : MonoBehaviour
{
    public GameObject findCam;
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Player Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //findCam = camera;
    }

    
}
