using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    public Transform spawn;
    public GameObject desirableObj;
    public string watchYaWant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == watchYaWant)
        {
            desirableObj.transform.position = spawn.transform.position;
            Debug.Log("Transforming desireable Object Position");
        }
    }
}
