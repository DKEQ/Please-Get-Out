using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFreeze : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thePhysgun;
    public PhysGun physgunScript;
    public GameObject freezeConfirmation;
    public GameObject freeze_UI;
    public GameObject grabUI;
    //public GameObject off;

    public AudioSource rampUp;
    public AudioSource rampDown;
    public AudioSource freezeLoop;
    public AudioSource aquired;
    public AudioSource targetFrozen;
    public AudioSource targetDropped;
    public AudioSource aquiredTargetImpact;
    private bool grabbedOnLastFrame;
    private bool frozenOnLastFrame;
    //public AudioSource 
    void Start()
    {
        physgunScript = thePhysgun.GetComponent<PhysGun>();
        grabbedOnLastFrame=false;
        frozenOnLastFrame=false;
    }

    // Update is called once per frame
    void Update()
    {
        if  (!PauseMenuUI.isPaused)
            {
                if(thePhysgun.GetComponent<PhysGun>()._isGrabbed==true)
                {
                    Debug.Log("Item Grabbed");
                    freeze_UI.SetActive(false);
                    
                    
                }
                if(thePhysgun.GetComponent<PhysGun>().isFrozen==true) 
                {
                    print("Saul");
                    freezeConfirmation.SetActive(true);
                    freeze_UI.SetActive(true);
                    grabUI.SetActive(false);
                    
                    //off.SetActive(false);
                }
                else
                {
                    freezeConfirmation.SetActive(false);
                    freeze_UI.SetActive(false);
                    grabUI = null;
                    
                    //off.SetActive(true);  
                }  
            }     
    }

    void FixedUpdate()
    {
        if  (!PauseMenuUI.isPaused)
            {
                if(!grabbedOnLastFrame && thePhysgun.GetComponent<PhysGun>()._isGrabbed==true)
                {
                    
                    aquired.Play();
                    targetDropped.Stop();
                    aquiredTargetImpact.Play();
                    Time.timeScale = 1f;

                }
                else if(grabbedOnLastFrame && thePhysgun.GetComponent<PhysGun>()._isGrabbed==false)
                {
                    aquired.Stop();
                    targetDropped.Play();
                    aquiredTargetImpact.Play();

                }
                if(!frozenOnLastFrame && thePhysgun.GetComponent<PhysGun>().isFrozen==true) 
                {
                    
                    targetFrozen.Play();
                    targetDropped.Stop();
                    aquiredTargetImpact.Play();
                    rampUp.Play();
                    freezeLoop.Play();
                    rampDown.Stop();
                    //off.SetActive(false);
                    Time.timeScale = 0.5f;
                }
                else if(frozenOnLastFrame && thePhysgun.GetComponent<PhysGun>().isFrozen==false) 
                {
                    
                    targetDropped.Play();

                    rampUp.Stop();
                    freezeLoop.Stop();
                    rampDown.Play();
                    //off.SetActive(true);  
                }  
            } 

        grabbedOnLastFrame = physgunScript._isGrabbed;
        frozenOnLastFrame = physgunScript.isFrozen;
    }

   /* void PlayAquired_SFX()
    {
        if(!physgunScript._isGrabbed)
        {
        aquired.Play();
        }
    }
    void PlayTargetFrozen_SFX()
    {
        if(!physgunScript.isFrozen)
        {
        targetFrozen.Play();
        }
    }

    void PlayTargetDropped_SFX()
    {
        if(!physgunScript._isGrabbed)
        {
        targetDropped.Play();
        }
    } */

}
