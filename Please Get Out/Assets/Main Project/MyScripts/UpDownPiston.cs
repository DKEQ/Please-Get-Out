using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPiston : MonoBehaviour
{
    public float directionalSpeed = -1;
    public GameObject pistonCompress;
    public Transform correctionPoint;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       //directionalSpeed = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0,directionalSpeed,0);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "TOP")
        {
            directionalSpeed = -2f;
        }
        
        if(col.gameObject.tag == "BOTTOM")
        {
            directionalSpeed = 4f;
        }

        if(col.gameObject.tag == "PistonCorrection")
        {
            transform.position = correctionPoint.position;
        }
    }
}
