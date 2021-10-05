using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
/////////////////START OF CODE///////////////////

/////////////////////////////////////////////////

/////////////////Varribles///////////////////
    /* public GameObject thePlayerMovement;
    public PlayerMovement playerMovementScript; */
    public GameObject toolTipObject_1;
    public GameObject toolTipObject_2;
    private bool waitForLastFrame;
    public AudioSource toolTipSFX;
    public GameObject enterCollider;
    //public AudioSource sprinting;
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Start()
    {
        toolTipObject_1.SetActive(false);
        toolTipObject_2.SetActive(false);
        waitForLastFrame = false;
        //enterCollider.GetComponent<MeshRenderer>();
        enterCollider.GetComponent<MeshRenderer>().enabled = false;
    }


    
    public void OnTriggerEnter(Collider other)
    {
        if  (other.gameObject.tag == "Player")
        {
            toolTipObject_1.SetActive(true);
            toolTipObject_2.SetActive(false);
            toolTipSFX.Play();
            Debug.Log(toolTipSFX);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if  (other.gameObject.tag == "Player")
        {
            toolTipObject_1.SetActive(false);
            toolTipObject_2.SetActive(true);
        }
    }









































}
/////////////////END OF CODE///////////////////
