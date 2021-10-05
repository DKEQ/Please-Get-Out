using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Threading.Tasks;
public class PauseMenuUI : MonoBehaviour
{
//////////////////////////////START OF CODE/////////////////////////////////////////////////////  

///////////////////////////////PLACE TO PUT VARRIBLES///////////////////////////////////////////////////////
    public GameObject   pauseMenu;

    public static bool isPaused;

    public static PauseMenuUI instance;

    ///Dealing with Music playing
    public AudioSource gameMusic;
    public AudioSource pauseMenuMusic;
    public AudioSource gameAmbience;
    private bool    pauseState;
    private bool    resetState;
    public static bool gamePaused;
    

    public UnityEvent   unloadCurrentScene;

    public UnityEvent   goBackToMainMenuScene;
    public  GameObject CamMovementCamParent;
    //public string scriptInQuestion;
    //public GameObject   thePlayer;

    public CharacterController theCharController;
    public GameObject thePhysgun;





//////////////////////////////PLACE TO PUT FUNCTION METHODS//////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        gamePaused = false;
        //thePlayer.GetComponent<CharacterController>();
        //pauseState  =   false;
        //resetState  =   false;
        //fpsPlayerCamMovement = GetComponent<CameraMovement>();
        //physgunScript = thePhysgun.GetComponent<PhysGun>();
        //CamMovementCamParent.GetComponent(scriptInQuestion) as 
        isPaused    =   false;
        //thePhysgun.SetActive(true);
    }
    void Awake()
    {   
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.Escape))
        {
            if  (isPaused)
            {
                
                ResumeGame();
                /* gameMusic.Play();
                gameAmbience.Play();
                pauseMenuMusic.Stop(); */
                
            }

            else
            {
                PauseGame();
                /* gameMusic.Pause();
                gameAmbience.Pause();
                pauseMenuMusic.Play(0); */
                
               
                
                
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale  =   0.05f;
        isPaused    =   true;
        theCharController.enabled   =   false;

        Cursor.visible  =   true;
        //Screen.lockCursor   =   false;
        gameMusic.Pause();
        gameAmbience.Pause();
        pauseMenuMusic.Play(0);
        thePhysgun.SetActive(false);
    }
    public void ResumeGame()
    {
        theCharController.enabled   =   true;
        pauseMenu.SetActive(false);
        Time.timeScale  =   1f;
        isPaused    =   false;
        gameMusic.Play();
        gameAmbience.Play();
        pauseMenuMusic.Stop();
        thePhysgun.SetActive(true);
        Cursor.visible  =   false;
        //Screen.lockCursor   =   true;
        
        
    }

    public async void GoToMainMenu()
    {
        Time.timeScale  =   1f;
        unloadCurrentScene.Invoke();
        //await Task.Delay(200);
        goBackToMainMenuScene.Invoke();
        //GameManager.instance.LoadMain_Menu();
    }





































}
//////////////////////////////END OF CODE/////////////////////////////////////////////////////    