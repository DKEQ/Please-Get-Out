using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepManager : MonoBehaviour
{
/////////////////START OF CODE///////////////////

/////////////////////////////////////////////////

/////////////////Varribles///////////////////
    public GameObject thePlayerController;
    public PlayerController playerControllerScript;
    public AudioSource[] footStepsStatus;
    //public AudioSource sprinting;
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = thePlayerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (playerControllerScript.isSprinting())
        {
            Sprinting();
        }
        else if (playerControllerScript.isWalking())
        {
            Walking();
        }


        else 
        {
            Standing();
        }
        

    }
    void Sprinting()
        {
            if  (!footStepsStatus[1].isPlaying)
            {
            footStepsStatus[1].Play();
            footStepsStatus[0].Stop();
            //footStepsStatus[1].Stop(); 
            //sprinting.Speed(0.1f);
            }
        }

    void Walking()
        {
            if  (!footStepsStatus[0].isPlaying)
            {
            footStepsStatus[1].Stop();
            footStepsStatus[0].Play();
            }
        }

    void Standing()
        {
           footStepsStatus[0].Stop();
            footStepsStatus[1].Stop(); 
        }















































}
/////////////////END OF CODE///////////////////