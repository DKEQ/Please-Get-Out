using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPiston : MonoBehaviour
{
    public float directionalSpeed = -1;
    public GameObject pistonCompress;
    public Transform correctionPoint;
    public string condition1;
    public string condition2;
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
        rb.velocity = new Vector3(directionalSpeed,0,0);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == condition1)
        {
            directionalSpeed = -2f;
        }
        
        if(col.gameObject.tag == condition2)
        {
            directionalSpeed = 4f;
        }

        if(col.gameObject.tag == "PistonCorrection")
        {
            transform.position = correctionPoint.position;
        }
    }
}
