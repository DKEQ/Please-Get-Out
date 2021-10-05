using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoadingScreenMusic : MonoBehaviour
{
//////////////////START OF CODE///////////////////////////

//////////////////////////////////////////////////////////

/////////////////VARRIBLES//////////////////////////////////
    public GameObject loadingScreen;
    public bool activeCheck;
    public AudioSource loadingMusic;
///////////////////////////////////////////////////////////

////////////////FUNCTIONS///////////////////////////////////

    
    void Start()
    {
        activeCheck = false;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (loadingScreen.activeInHierarchy && !activeCheck)
        {
            loadingMusic.Play();
            
        }
        else if (!loadingScreen.activeInHierarchy && activeCheck)
        {
            loadingMusic.Stop();
            activeCheck = false;
        }
        activeCheck = loadingScreen.activeInHierarchy;
    }

/////////////////////////////////////////////////////////////



}
////////////////END OF CODE///////////////////////////////////////////////