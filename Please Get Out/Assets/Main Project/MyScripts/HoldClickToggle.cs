using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClickToggle : MonoBehaviour
{
    public GameObject onOffToggle;

    public GameObject thePhysGun;
    public PhysGun physgunScript;
    //public int DesiredMouseKey = 0;
    // Start is called before the first frame update
    void Start()
    {
        physgunScript = thePhysGun.GetComponent<PhysGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thePhysGun.GetComponent<PhysGun>()._isGrabbed==true)
        {
            Debug.Log("Item Grabbed");
            onOffToggle.SetActive(true);
            
        }

        else
        {
            Debug.Log("Item Dropped/ Frozen");
            onOffToggle.SetActive(false);
            
        }
    }
}
