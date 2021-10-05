using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityScript.Scripting;
public class WaitSecondsToChangeScene : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////
{
    //Variables to tell stuff what to do
    [SerializeField]
    private float delayBeforeLoading = 10f;
    
    [SerializeField]
    public int sceneNumberToLoad;
    private float timeElapsed;

    private GameManager gameManager; 
    //public GameObject myGameManager;



    public void Start()
    {
        //myGameManager.GetComponent<GameManager>().LoadMain_Menu();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > delayBeforeLoading)
        {
            /* SceneManager.UnloadSceneAsync((int)SceneIndexes.INTRO_SCREEN);
            SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN); */

            gameManager.LoadMain_Menu();
        }
        //DontDestroyOnLoad(theGameManager.gameObject);

        if(Input.GetMouseButtonDown(0))
        {
            gameManager.LoadMain_Menu();
   
   
        }
    }

    

   


































}
////////////////////////////////END OF SCRIPT////////////////////////////////