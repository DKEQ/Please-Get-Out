using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPressurePlate : MonoBehaviour
{
/////////////////START OF CODE///////////////////

/////////////////////////////////////////////////

/////////////////Varribles///////////////////
    public GameObject PhysicsWall;

    public string keyDeviceTag;
    private string micDeviceTag = "MIC_Key";
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Start()
    {
        PhysicsWall.SetActive(true);
        Debug.Log("Wall Locked");
    }


    
    public void OnTriggerEnter(Collider other)
    {
        if  (other.gameObject.tag == "Player")
        {
            PhysicsWall.SetActive(false);
            Debug.Log("Wall Unlocked");
        }

        if  (other.gameObject.tag == keyDeviceTag)
        {
            PhysicsWall.SetActive(false);
            Debug.Log("Wall Unlocked");
        }
        if  (other.gameObject.tag == micDeviceTag)
        {
            PhysicsWall.SetActive(false);
            Debug.Log("Wall Unlocked");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if  (other.gameObject.tag == "Player")
        {
            PhysicsWall.SetActive(true);
            Debug.Log("Wall Locked");
        }

        if  (other.gameObject.tag == keyDeviceTag)
        {
            PhysicsWall.SetActive(true);
            Debug.Log("Wall Locked");
        }

        if  (other.gameObject.tag == micDeviceTag)
        {
            PhysicsWall.SetActive(true);
            Debug.Log("Wall Locked");
        }
    }









































}
/////////////////END OF CODE///////////////////
