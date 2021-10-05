using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

//All in one Menu UI Manager//
//Different functions will either be their own menu's or direct function runs like "Quit game"
public class Menu_UI_Manager : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////

//Variables to tell stuff what to do

{
    //Level Select Screen : Level 1 , 2 , 3 etc (Function calls for Level Select Screen to be enbaled)
    public void Load_Level_1()
    {
        //load gameplay scene
        Debug.Log ("Loading Scene");
        //SceneManager.LoadScene(3);
        //LevelManager.Instance.LoadScene(3);
    }

//Options Screen : Accessibility, Controls, Audio
    public void OptionsSelect()
    {

    }

//Credits Screen : Who helped me create this game
    public void CreditsSelect()
    {

    }

//Quit Game Function (Direct Function)
    public void QuitGame()
    {
        Application.Quit();
    }









////////////////////////////////END OF SCRIPT////////////////////////////////
}
