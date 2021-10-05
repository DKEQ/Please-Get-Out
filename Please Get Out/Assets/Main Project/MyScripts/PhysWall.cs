using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysWall : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("You're holding the mouse button m8");
            on.SetActive(true);
            off.SetActive(false);
        }

        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Why did you let go? what the fuck??? Put your finger back >:( ");
            on.SetActive(false);
            off.SetActive(true);
        }
    }
}
