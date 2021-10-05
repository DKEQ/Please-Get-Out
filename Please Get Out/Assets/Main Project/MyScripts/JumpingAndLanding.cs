using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingAndLanding : MonoBehaviour
{
/////////////////START OF CODE///////////////////

/////////////////////////////////////////////////

/////////////////Varribles///////////////////
    /* public GameObject thePlayerMovement;
    public PlayerMovement playerMovementScript; */
    public AudioSource[] jumpStatus;
    /* public AudioClip jumpFX;
    public AudioClip landFX; */

    public CharacterController cc;
    public PlayerMovement playerMove;

    private bool hasJustLanded;

    private bool groundedLastFrame;
    public CollisionFX colFX;
    public GameObject MIC;
    public float shakeLength;
    public float shakeStrength;

    //public AudioSource sprinting;
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Start()
    {
        //playerMovementScript = thePlayerMovement.GetComponent<PlayerMovement>();
        hasJustLanded = false;
        groundedLastFrame = false;
        colFX = MIC.GetComponent<CollisionFX>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if  (!groundedLastFrame && playerMove.grounded)
        {
            Debug.Log("you have landed");
           colFX.StartShakeEffect(shakeLength    ,   shakeStrength);
            jumpStatus[0].Play();
            //Debug.Log("you have landed");
            
        }
        
        if  (playerMove.grounded)
        {
            Debug.Log("test");
        }

        if(Input.GetButtonDown("Jump") && playerMove.grounded)
            {
                
                jumpStatus[1].Play();
                Debug.Log("you are now jumping");
                //jumpStatus[1].isPlaying = false;
                
                
            }
        /* else if (playerMove.grounded)
            {
                if (!hasJustLanded)
                if(!jumpStatus[0].isPlaying)
                    
                        // Play cool landing sound
                        hasJustLanded = false;
                        /* jumpStatus[0].Play();
                        Debug.Log("you have landed"); */
                       // jumpStatus[0].isPlaying = false;
                    
           // } 
        groundedLastFrame = playerMove.grounded;
    }

    
    /* void PlayJumpSFX()
        {
            if  (!jumpStatus[1].isPlaying)
            {
            jumpStatus[1].Play();
            //jumpStatus[0].Stop();
            //jumpStatus[1].Stop(); 
            //sprinting.Speed(0.1f);
            }
        }

    void Landing()
        {
            if  (!jumpStatus[0].isPlaying)
            {
            //jumpStatus[1].Stop();
            jumpStatus[0].Play();
            }
        }
 */
    /* void OnCollisionEnter (Collision col)
  {
      
      bool canPlayJumpLandingSound;
      if (col.gameObject.tag == "Ground") 
      {
          canPlayJumpLandingSound = true;
          if(!jumpStatus.isPlaying && canPlayJumpLandingSound == true)
          {
              canPlayJumpLandingSound = false;
              jumpStatus.PlayOneShot(landFX,1f);
          }
      }
  } */















































}
/////////////////END OF CODE///////////////////