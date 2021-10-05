using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using UnityEngine.UI;
public class ChangeLevel : MonoBehaviour
{
    public Animator transition;
    
      [SerializeField] public int Level;
      [SerializeField] public int SameLevel;
       [SerializeField] int time;
       private Scene scene;

       //public TheGameManager gameManagerScript;

       public UnityEvent nextLevel;
       public UnityEvent theSameLevel;

       

       

       //private GameManager gmScript;
       
       //float timer;
       //public float holdButtonDuration = 3f;
        [Tooltip ("Key you are using to hold")]     public KeyCode Key;
        [Tooltip ("Bool for buttonDown")]     private   bool    buttonDown;
        [Tooltip ("Long Press Event")]     public UnityEvent onLongPress;
        [SerializeField] [Tooltip ("How long you want to hold the button for")]     public float requiredHoldTime;
        [Tooltip ("The timer")]         private float buttonDownTimer;
        [Tooltip ("Loading Text Object")]      public  GameObject   ui_TextObject;
        [Tooltip ("Loading ToolTipText Object")]      public  GameObject   ui_TextToolTipObject;
        [SerializeField] [Tooltip ("UI circle image that will have 360 radial wipe ")]      private Image ui_circle_fill;
        
        
         

         //private float target;
    //public IDictionaryEnumerator SceneIndexes;
    //public int  restartLevelInt;

    public void OnButtonDown() 
    {
        buttonDown  = true;
        Debug.Log("ButtonHeldDown");
    }

    public void OnButtonUp() 
    {
        Reset();
        Debug.Log("ButtonRelased");
    }




    void Start()
    {
        scene = SceneManager.GetActiveScene();
        //buttonDownTimer   =   0;
        ui_circle_fill.fillAmount = 0;
        ui_TextObject.gameObject.SetActive(false);
        ui_TextToolTipObject.gameObject.SetActive(true);
        
    }
     
    
    // Update is called once per frame
    private void Update()
    {
        
       /*  float heldTime = buttonDownTimer / requiredHoldTime;
        ui_circle_fill.fillAmount  =   heldTime;
        if  (Input.GetKeyDown(Key))
        {
            
            ui_TextObject.gameObject.SetActive(true);
            ui_TextToolTipObject.gameObject.SetActive(false);
            buttonDownTimer   +=  Time.timeScale;
        if  (buttonDownTimer  >=   requiredHoldTime)
                {
                    
                    //Restart Level Code
                    print("Restarting Level");
                    //startTime = 0f;
                    Invoke("ResetScene",3f);
                }
            //Invoke("HoldingDownTheButton",0.5f);
        }
        else if (Input.GetKeyUp(Key))
        {
            buttonDownTimer   =   0;
            
            ui_TextObject.gameObject.SetActive(false);
            ui_TextToolTipObject.gameObject.SetActive(true);
            
        } */
                if  (!PauseMenuUI.isPaused)
                {
                    if  (Input.GetKeyDown(Key))
                        {
                            Invoke("OnButtonDown",0.5f);
                            ui_TextObject.gameObject.SetActive(true);
                            ui_TextToolTipObject.gameObject.SetActive(false);
                        }
                    else if (Input.GetKeyUp(Key))
                        {
                            Invoke("OnButtonUp",0f);
                            ui_TextObject.gameObject.SetActive(false);
                            ui_TextToolTipObject.gameObject.SetActive(true);
                        }




                    if  (buttonDown)
                    {
                        buttonDownTimer += Time.deltaTime;
                        if  (buttonDownTimer    >=   requiredHoldTime)
                        {
                            if  (onLongPress    !=  null)
                                onLongPress.Invoke();
                                print("Restarting Level");
                                ui_TextObject.gameObject.SetActive(true);
                                ui_TextToolTipObject.gameObject.SetActive(false);
                                //Invoke("ResetScene",3f);
                                Reset();
                        }
                        ui_circle_fill.fillAmount   =   buttonDownTimer /   requiredHoldTime;

                    }
                }   
    }

    private void Reset()
    {
            buttonDown  =   false;
            buttonDownTimer =   0;
            ui_circle_fill.fillAmount   =   buttonDownTimer     /   requiredHoldTime;
            
    }

   /*  private void HoldingDownTheButton()
    {
            buttonDownTimer   +=  Time.realtimeSinceStartup;
        if  (buttonDownTimer  >=   secondsToWait)
                {
                    //buttonDownTimer   =   0;
                    //Restart Level Code
                    print("Restarting Level");
                    //startTime = 0f;
                    Invoke("ResetScene",3f);
                }

    } */

    /* private void FixedUpdate()
    {
        float heldTime = buttonDownTimer / secondsToWait;
        ui_circle_fill.fillAmount  =   heldTime;
        //Debug.Log("Loading");
    } */

    
    public async void ResetScene()
    {
        //await Task.Delay(2000);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        theSameLevel.Invoke();
        //await Task.Delay(2000);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        print("Scene is Reset");

        //NEXT TIME YOU SEE THIS, GO TO THE GAME MANAGER AND START CREATING UNLOAD_LEVEL_X FUNCTIONS SO THAT THE INVOKES OF THIS CODE CAN RESET THE SCENE FRESHLY SO IT HAS SOMETHING TO LOAD INTO. 
        //FOR EXAMPLE THIS CODE WILL DEAL WITH UNLOADING THE SPECIFIC SCENE USING INVOKE() WHILST THE GAMEMANAGER WILL DELAY THE LOADING OF THE SAME SCENE TO GIVE THE UNLOAD TIME TO REMOVE THE SPECIFIC SCENE
        //IT WILL CALL FOR ITSELF TO LOAD THE SCENE AGAIN WITH THE LOADING SCREEN VIA LOADLEVEL_X();
    }


    public void FadeToLevel ()
    {
        transition.SetTrigger("FadeOut");
    }
   public void OnTriggerEnter(Collider chkCol){
        if(chkCol.tag == "NextLevel"){
            Debug.Log ("Collision Detected Changing Scene");
            //SceneManager.LoadScene(Level);
            //LevelManager.Instance.LoadScene(Level);
            //FindObjectOfType<LevelManager>().LoadScene(Level);
            //gameManagerScript.sceneFunction.sceneNum.();
            //Invoke( callFunctionToNextLevel, 0f );
            //nextLevel.Invoke();
            //GameManager.instance.nextLevel.Invoke();
            nextLevel.Invoke();
            FadeToLevel();
        }
        if(chkCol.tag == "Hazard"){
            Debug.Log ("Player Hit Hazard Refreshing Scene");
            //SceneManager.LoadScene(SameLevel);
            //LevelManager.Instance.LoadScene(SameLevel);
            //FindObjectOfType<LevelManager>().LoadScene(SameLevel);
            //Invoke( callFunctionToRestart, 0f );
            //ResetScene();
            onLongPress.Invoke();
            FadeToLevel();
        }
    }
}
