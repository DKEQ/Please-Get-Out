using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EndTheGame : MonoBehaviour
{
public GameObject mainInteractCube;

    //public string keyDeviceTag;
    private string micDeviceTag = "MIC_Key";
    public UnityEvent nextLevel;
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Start()
    {
        mainInteractCube.SetActive(true);
        Debug.Log("MIC visible");
    }


    
    public void OnTriggerEnter(Collider other)
    {
        
        if  (other.gameObject.tag == micDeviceTag)
        {
            mainInteractCube.SetActive(false);
            nextLevel.Invoke();
            Debug.Log("MIC disabled");
            Debug.Log("Entering the Final Level");
        }
    }


















}
/////////////////////END OF SCRIPT//////////////////////
