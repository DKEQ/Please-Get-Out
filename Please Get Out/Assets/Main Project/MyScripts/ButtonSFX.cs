using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////
{
    //Variables to tell stuff what to do
    //Sound effect Audiosource target for script initialization
    public AudioSource mySFX;
    //Hover Sound effect sound clip
    public AudioClip hoverSFX;
    //Click Sound Effect Sound Clip
    public AudioClip clickSFX;



    ////ooooo functions
    //hover function to be be accessed every time certain events are met (hovering)
    public void HoverSound()
    {
        mySFX.PlayOneShot (hoverSFX);
    }

    //click function to be access every time you click down on the object
    public void ClickSound()
    {
        mySFX.PlayOneShot (clickSFX);
    }






}
////////////////////////////////END OF SCRIPT////////////////////////////////