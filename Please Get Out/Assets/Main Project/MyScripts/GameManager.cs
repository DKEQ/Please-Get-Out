/////NEW METHOD///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////  
{
////////////////Place to put variables//////////////////
    public static GameManager instance;//Instance Manager
    [SerializeField] private GameObject loadingScreen;///Assign loadingScreen
    [SerializeField] private Image progressBar;//The progress bar image using FillAmount as the slider
    [SerializeField] private Slider progressBarSlider;//The progress bar image using FillAmount as the slider

    //[SerializeField] private Toggle selectedToggle;
    [SerializeField] public GameObject toggledCB_Mode;

    [SerializeField] private bool restartCheck; 
    
    


    private float target;
////////////////Place to put functions//////////////////

    void Awake()
    {   
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.INTRO_SCREEN, LoadSceneMode.Additive);
        loadingScreen.SetActive(false);//will be made invisible at the end of the transistion period
        //selectedToggle = GetComponent<Toggle>();
        //selectedToggle.onValueChanged.AddListener(delegate  {ToggleValueChangedOccured(selectedToggle);});
        toggledCB_Mode.SetActive(false);
        print("toggle Disabled Automatically");
        restartCheck = false;
    }

    public void ToggleValueChangedOccured(bool tglValue)
    {
        toggledCB_Mode.SetActive(tglValue);
        print(tglValue);
    }

    
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();//creates lists of Asyncronous operations
    public async void LoadMain_Menu()//To initialize the loading proceedure using Coroutines
    {
        //START LOADING Main_Menu
        Debug.Log("Loading the Main Menu");
        StartCoroutine(StartLoading_Main_Menu());
    }
    
        IEnumerator StartLoading_Main_Menu()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_IntroScene = SceneManager.UnloadSceneAsync((int)SceneIndexes.INTRO_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_Main_Menu = SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_Main_Menu.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_Main_Menu.isDone)
                    {
                            Debug.Log(asyncOperation_Load_Main_Menu.progress * 100);
                            target = asyncOperation_Load_Main_Menu.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)

                                    {
                                        
                                        asyncOperation_Load_Main_Menu.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LoadMain_MenuFrom_Level_10()//To initialize the loading proceedure using Coroutines
    {
        //START LOADING Main_Menu
        Debug.Log("Loading the Main Menu");
        StartCoroutine(StartLoading_LoadMain_MenuFrom_Level_10());
        restartCheck = true;
        Time.timeScale = 1f;
    }
    
        IEnumerator StartLoading_LoadMain_MenuFrom_Level_10()
        {
            yield return null;
            
            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            Cursor.visible  =   true;
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState
            AsyncOperation asyncOperation_Unload_LEVEL_10 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_10);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_Main_Menu = SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_Main_Menu.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_Main_Menu.isDone)
                    {
                            Debug.Log(asyncOperation_Load_Main_Menu.progress * 100);
                            target = asyncOperation_Load_Main_Menu.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_Main_Menu.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LoadMain_Menu_From_AnyScene()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading the Main Menu");
        StartCoroutine(StartLoading_Main_MenuFromAnyScene());
        restartCheck = true;
        Time.timeScale = 1f;
        

        
    }
    IEnumerator StartLoading_Main_MenuFromAnyScene()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            //AsyncOperation asyncOperation_Unload_IntroScene = SceneManager.UnloadSceneAsync((int)SceneIndexes.INTRO_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_Main_MenuFromAnyScene = SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_Main_MenuFromAnyScene.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_Main_MenuFromAnyScene.isDone)
                    {
                            Debug.Log(asyncOperation_Load_Main_MenuFromAnyScene.progress * 100);
                            target = asyncOperation_Load_Main_MenuFromAnyScene.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_Main_MenuFromAnyScene.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                        restartCheck = false;
                                    }
                                    
                            yield return null;
                    }
                    
        }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    
    public async void LoadLEVEL_1()
    {
        //START LOADING LEVEL_1
        Debug.Log("Loading the LEVEL_1");
        StartCoroutine(StartLoading_LoadLEVEL_1());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_1()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_1 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_1.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_1.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_1.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_1.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_1.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_1_RestartProceedure()
    {
        //START LOADING LEVEL_1 Again
        Debug.Log("Loading the LEVEL_1");
        StartCoroutine(StartLoading_LEVEL_1_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
        //await.TaskDelay(100);
    }

    IEnumerator StartLoading_LEVEL_1_RestartProceedure()
        {
            yield return null;
            //Await.TaskDelay();
            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_1_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_1_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_1_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_1_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_1_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_1_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_1_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_1_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_1_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_1_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_1_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_1_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_1_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_1 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_1_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_1_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_1 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_1.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_1.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_1.progress * 100);
                            target = asyncOperation_Load_LEVEL_1.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_1.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

public async void LoadLEVEL_2()
    {
        //START LOADING LEVEL_2
        Debug.Log("Loading the LEVEL_2");
        StartCoroutine(StartLoading_LoadLEVEL_2());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_2()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_1 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_2 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_2.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_2.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_2.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_2.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_2.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_2_RestartProceedure()
    {
        //START LOADING LEVEL_2 Again
        Debug.Log("Loading the LEVEL_2");
        StartCoroutine(StartLoading_LEVEL_2_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_2_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_2_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_2);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_2_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_2_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_2_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_2_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_2_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_2_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_2_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_2_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_2_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_2_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_2_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_2);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_2_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_2 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_2_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_2_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_Main_Menu = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_Main_Menu.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_Main_Menu.isDone)
                    {
                            Debug.Log(asyncOperation_Load_Main_Menu.progress * 100);
                            target = asyncOperation_Load_Main_Menu.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_Main_Menu.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    

public async void LoadLEVEL_3()
    {
        //START LOADING LEVEL_3
        Debug.Log("Loading the LEVEL_3");
        StartCoroutine(StartLoading_LoadLEVEL_3());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_3()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_2 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_2);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_3 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_3    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_3.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_3.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_3.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_3.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_3.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_3_RestartProceedure()
    {
        //START LOADING LEVEL_3 Again
        Debug.Log("Loading the LEVEL_3");
        StartCoroutine(StartLoading_LEVEL_3_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_3_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_3_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_3);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_3_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_3    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_3_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_3_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_3_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_3_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_3_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_3_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_3_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_3_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_3_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_3_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_3);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_3_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_3 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_3_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_3_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_3 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_3    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_3.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_3.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_3.progress * 100);
                            target = asyncOperation_Load_LEVEL_3.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_3.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 


    public async void LoadLEVEL_4()
    {
        //START LOADING LEVEL_4
        Debug.Log("Loading the LEVEL_4");
        StartCoroutine(StartLoading_LoadLEVEL_4());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_4()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_3 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_3);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_4 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_4    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_4.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_4.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_4.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_4.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_4.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_4_RestartProceedure()
    {
        //START LOADING LEVEL_4 Again
        Debug.Log("Loading the LEVEL_4");
        StartCoroutine(StartLoading_LEVEL_4_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_4_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_4_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_4);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_4_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_4    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_4_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_4_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_4_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_4_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_4_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_4_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_4_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_4_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_4_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_4_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_4);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_4_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_4 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_4_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_4_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_4 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_4    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_4.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_4.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_4.progress * 100);
                            target = asyncOperation_Load_LEVEL_4.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_4.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 



    public async void LoadLEVEL_5()
    {
        //START LOADING LEVEL_5
        Debug.Log("Loading the LEVEL_5");
        StartCoroutine(StartLoading_LoadLEVEL_5());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_5()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_4 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_4);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_5 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_5    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_5.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_5.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_5.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_5.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_5.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_5_RestartProceedure()
    {
        //START LOADING LEVEL_5 Again
        Debug.Log("Loading the LEVEL_5");
        StartCoroutine(StartLoading_LEVEL_5_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_5_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_5_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_5);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_5_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_5    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_5_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_5_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_5_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_5_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_5_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_5_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_5_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_5_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_5_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_5_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_5);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_5_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_5 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_5_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_5_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_5 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_5    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_5.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_5.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_5.progress * 100);
                            target = asyncOperation_Load_LEVEL_5.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_5.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 





    public async void LoadLEVEL_6()
    {
        //START LOADING LEVEL_6
        Debug.Log("Loading the LEVEL_6");
        StartCoroutine(StartLoading_LoadLEVEL_6());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_6()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_5 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_5);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_6 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_6    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_6.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_6.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_6.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_6.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_6.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_6_RestartProceedure()
    {
        //START LOADING LEVEL_6 Again
        Debug.Log("Loading the LEVEL_6");
        StartCoroutine(StartLoading_LEVEL_6_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_6_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_6_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_6);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_6_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_6    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_6_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_6_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_6_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_6_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_6_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_6_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_6_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_6_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_6_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_6_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_6);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_6_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_6 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_6_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_6_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_6 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_6    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_6.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_6.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_6.progress * 100);
                            target = asyncOperation_Load_LEVEL_6.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_6.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 




    public async void LoadLEVEL_7()
    {
        //START LOADING LEVEL_7
        Debug.Log("Loading the LEVEL_7");
        StartCoroutine(StartLoading_LoadLEVEL_7());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_7()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_6 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_6);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_7 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_7    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_7.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_7.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_7.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_7.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_7.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_7_RestartProceedure()
    {
        //START LOADING LEVEL_7 Again
        Debug.Log("Loading the LEVEL_7");
        StartCoroutine(StartLoading_LEVEL_7_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_7_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_7_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_7);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_7_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_7    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_7_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_7_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_7_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_7_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_7_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_7_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_7_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_7_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_7_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_7_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_7);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_7_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_7 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_7_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_7_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_7 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_7    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_7.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_7.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_7.progress * 100);
                            target = asyncOperation_Load_LEVEL_7.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_7.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 



    public async void LoadLEVEL_8()
    {
        //START LOADING LEVEL_8
        Debug.Log("Loading the LEVEL_8");
        StartCoroutine(StartLoading_LoadLEVEL_8());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_8()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_7 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_7);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_8 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_8    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_8.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_8.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_8.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_8.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_8.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_8_RestartProceedure()
    {
        //START LOADING LEVEL_8 Again
        Debug.Log("Loading the LEVEL_8");
        StartCoroutine(StartLoading_LEVEL_8_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_8_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_8_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_8);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_8_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_8    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_8_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_8_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_8_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_8_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_8_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_8_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_8_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_8_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_8_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_8_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_8);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_8_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_8 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_8_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_8_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_8 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_8    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_8.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_8.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_8.progress * 100);
                            target = asyncOperation_Load_LEVEL_8.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_8.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 




    public async void LoadLEVEL_9()
    {
        //START LOADING LEVEL_9
        Debug.Log("Loading the LEVEL_9");
        StartCoroutine(StartLoading_LoadLEVEL_9());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_9()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_8 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_8);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_9 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_9    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_9.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_9.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_9.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_9.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LoadLEVEL_9.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_9_RestartProceedure()
    {
        //START LOADING LEVEL_9 Again
        Debug.Log("Loading the LEVEL_9");
        StartCoroutine(StartLoading_LEVEL_9_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_9_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_9_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_9);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_9_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_9    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_9_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_9_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_9_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_9_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_9_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_9_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_9_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_9_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_9_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_9_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_9);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_9_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_9 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_9_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_9_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_9 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_9    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_9.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_9.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_9.progress * 100);
                            target = asyncOperation_Load_LEVEL_9.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_9.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 



    public async void LoadLEVEL_10()
    {
        //START LOADING LEVEL_10
        Debug.Log("Loading the LEVEL_10");
        StartCoroutine(StartLoading_LoadLEVEL_10());
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LoadLEVEL_10()
        {
            yield return null;
            restartCheck = true;
            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_9 = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_9);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LoadLEVEL_10 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_10    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LoadLEVEL_10.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LoadLEVEL_10.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LoadLEVEL_10.progress * 100);
                            target = asyncOperation_Load_LoadLEVEL_10.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LoadLEVEL_10.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }

    public async void LEVEL_10_RestartProceedure()
    {
        //START LOADING LEVEL_10 Again
        Debug.Log("Loading the LEVEL_10");
        StartCoroutine(StartLoading_LEVEL_10_RestartProceedure());
        restartCheck = true;
        Time.timeScale = 1f;
    }

    IEnumerator StartLoading_LEVEL_10_RestartProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_LEVEL_10_RestartProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_10);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_10_RestartProceedure = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_10    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_10_RestartProceedure.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_10_RestartProceedure.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_10_RestartProceedure.progress * 100);
                            target = asyncOperation_Load_LEVEL_10_RestartProceedure.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        restartCheck = false;
                                        asyncOperation_Load_LEVEL_10_RestartProceedure.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
    public async void LEVEL_10_CompleteUnLoadProceedure()
    {
        
        //START LOADING LEVEL_10_Complete
        Debug.Log("Unloading current level");
        StartCoroutine(StartLoading_LEVEL_10_CompleteUnLoadProceedure());
       
    }

    IEnumerator StartLoading_LEVEL_10_CompleteUnLoadProceedure()
        {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            AsyncOperation asyncOperation_Unload_LEVEL_10_CompleteUnLoadProceedure = SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_10);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                
                    
        }


        public async void LoadLEVEL_10_DevMode()
    {
       //START LOADING Main_MenuFromAnyScene
        Debug.Log("Loading LEVEL_10 from main menu");
        StartCoroutine(StartLoading_LoadLEVEL_10_DevMode());
    }
    IEnumerator StartLoading_LoadLEVEL_10_DevMode()
    {
            yield return null;

            //Start to Unload the previous Sceme in place of the loading screen
            loadingScreen.SetActive(true);//will be made visible over the screen in the transistion period
            target = 0;
            progressBar.fillAmount = 0;
            progressBarSlider.value = 0;
            AsyncOperation asyncOperation_Unload_Previous_Scene = SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN);
            //Start to Load the required Sceme
            AsyncOperation asyncOperation_Load_LEVEL_10 = SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_10    ,LoadSceneMode.Additive);
                Application.backgroundLoadingPriority = ThreadPriority.Low;
                asyncOperation_Load_LEVEL_10.allowSceneActivation  =   false;

                    while (!asyncOperation_Load_LEVEL_10.isDone)
                    {
                            Debug.Log(asyncOperation_Load_LEVEL_10.progress * 100);
                            target = asyncOperation_Load_LEVEL_10.progress * 100;
                            if  (Mathf.Abs(progressBarSlider.value - 1.0f) < 0.0000001f) //(progressBarSlider.value == 1f)
                                    {
                                        
                                        asyncOperation_Load_LEVEL_10.allowSceneActivation  =   true;
                                        loadingScreen.SetActive(false);
                                        Debug.Log("Level Has Successfully loaded!");
                                    }
                                    
                            yield return null;
                    }
                    
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    /* public void CB_Status()
    {
        colourBlindenessMode.S = !colourBlindenessMode.SetActive(true);
    } */

    /* public void CB_Status_No()
    {
        colourBlindenessMode = false;
    } */

    /* async void Update()
    {
        if  (colourBlindenessMode)
        {
            colourBlindAccess.SetActive(true);
        }
        else
        {
            colourBlindAccess.SetActive(false);
        }
    } */
    void FixedUpdate()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, Time.deltaTime * 3  );
        //progressBarSlider.value = Mathf.MoveTowards(progressBarSlider.value, target, Time.deltaTime / 36);

        if  (!restartCheck)
        {
            progressBarSlider.value = Mathf.MoveTowards(progressBarSlider.value, target, Time.deltaTime / 18);
        }

        else
        {
            progressBarSlider.value = Mathf.MoveTowards(progressBarSlider.value, target, Time.deltaTime * 2);
        }
        

    }






































}

/////////////////////////////END OF CODE///////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




////////////OLD METHOD/////////////
/* 
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class TheGameManager : MonoBehaviour
//
{
//
////////////////START OF SCRIPT///////////////////////

////////////////Place to put variables//////////////////
    public static TheGameManager instance;//Instance Manager
    public GameObject loadingScreen;///Assign loadingScreen
    public Image progressBar;
////////////////Place to put functions//////////////////

    public void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.INTRO_SCREEN, LoadSceneMode.Additive);
    }

    
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();//creates lists of Asyncronous operations
    
    public async void LoadMain_Menu()
    {
        loadingScreen.gameObject.SetActive(true);
        await Task.Delay(10000);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.INTRO_SCREEN));
        await Task.Delay(10000);
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN    ,LoadSceneMode.Additive));
        

        StartCoroutine  (GetSceneLoadProgress());
    }
    
    public async void LoadLevel_1()
    {
        loadingScreen.gameObject.SetActive(true);
        await Task.Delay(10000);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN));
        await Task.Delay(10000);
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());
    }

    public async void LoadLevel_2()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());
    }

    public async void LoadLevel_3()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_2));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_3    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());
    }

    public async void LoadLevel_4()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_3));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_4    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    public async void LoadLevel_5()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_4));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_5    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    public async void LoadLevel_6()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_5));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_6    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    public async void LoadLevel_7()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_6));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_7    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    public async void LoadLevel_8()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_7));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_8    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    public async void LoadLevel_9()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_8));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_9    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    public async void LoadLevel_10()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_9));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_10    ,LoadSceneMode.Additive));

        StartCoroutine  (GetSceneLoadProgress());

    }

    float totalSceneProgress;
   public IEnumerator GetSceneLoadProgress()

   {
       for      (int i = 0; i < scenesLoading.Count; i++)

       {
           while        (   !scenesLoading[i]  .    isDone )
           
           {
               totalSceneProgress = 0;
               foreach(AsyncOperation operation in scenesLoading)
               {
                   totalSceneProgress += operation.progress;
               }

               totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;

               //progressBar.fillAmount = Mathf.RoundToInt(totalSceneProgress);
               //progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, totalSceneProgress, Time.maximumDeltaTime /27);
               yield        return null;

           }
       }


    
       loadingScreen.gameObject.SetActive(false);

   }

    void fixedUpdate()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, totalSceneProgress, Time.maximumDeltaTime /27);
    }












//
}
////////////////END OF SCRIPT///////////////////////
 */
////////////////OLD METHOD////////////////////////