/////NEW METHOD///

/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////  
{
////////////////Place to put variables//////////////////
    public static LevelManager instance;//Instance Manager
    public GameObject loadingScreen;///Assign loadingScreen
    public Image progressBar;//The progress bar image using FillAmount as the slider

    private float target;
////////////////Place to put functions//////////////////

public void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.INTRO_SCREEN, LoadSceneMode.Additive);
    }

    
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();//creates lists of Asyncronous operations
    
    public async void LoadMain_Menu()
    {
        target = 0;
        progressBar.fillAmount = 0;
        loadingScreen.gameObject.SetActive(true);//will be made visible over the screen in the transistion period
        await Task.Delay(3000); //3 second delay for stability
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.INTRO_SCREEN));//this previous scene will be unloaded in the background

        var introScene = SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN    ,LoadSceneMode.Additive);//varrible will be created to control scene activation
        introScene.allowSceneActivation = false;//scene activation will obviously be false at this period of time as its not read yet


        //////////////////////////////////
        do 
        {
            Debug.Log(introScene.progress);
            await Task.Delay(10000);
            //_progressBar.value = scene.progress;
            target = introScene.progress;
          //(cam.GetComponent(typeof(AudioListener)) as AudioListener).enabled = false;
        }
        while (introScene.progress < 0.9f);
        
        await Task.Delay(15000);
        
        introScene.allowSceneActivation = true;
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN    ,LoadSceneMode.Additive));
        await Task.Delay(3000);
        loadingScreen.SetActive(false);

        ////////////////////////////////
        
        

        
    }
    
    public async void LoadLevel_1()
    {
        loadingScreen.gameObject.SetActive(true);
        await Task.Delay(10000);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU_SCREEN));
        await Task.Delay(10000);
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1    ,LoadSceneMode.Additive));

        
    }

    public async void LoadLevel_2()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2    ,LoadSceneMode.Additive));

        
    }

    public async void LoadLevel_3()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_2));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_3    ,LoadSceneMode.Additive));

        
    }

    public async void LoadLevel_4()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_3));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_4    ,LoadSceneMode.Additive));

        

    }

    public async void LoadLevel_5()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_4));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_5    ,LoadSceneMode.Additive));

        

    }

    public async void LoadLevel_6()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_5));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_6    ,LoadSceneMode.Additive));

        

    }

    public async void LoadLevel_7()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_6));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_7    ,LoadSceneMode.Additive));

        

    }

    public async void LoadLevel_8()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_7));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_8    ,LoadSceneMode.Additive));

        

    }

    public async void LoadLevel_9()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_8));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_9    ,LoadSceneMode.Additive));

        

    }

    public async void LoadLevel_10()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_9));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_10    ,LoadSceneMode.Additive));

        

    }


    void FixedUpdate()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, Time.maximumDeltaTime / 27  );
    }






































}

/////////////////////////////END OF CODE///////////////////////////////////////


 */

 /////NEW METHOD /////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//////OLD METHOD//////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////  
{
    //Variables to tell stuff what to do
    [SerializeField] public static LevelManager Instance; 
    [SerializeField] private GameObject _loader_LoadingScreen;
    [SerializeField] private Image _progressBar;
    //[SerializeField] public AudioListener audioListener;
    public GameObject ears;
    public GameObject videoBG;
    private float target;
    void Start()
    {
        //audioListener = GetComponent<AudioListener>();

    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //ears = GameObject.Find("Player's Ears");

        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }


    public async void LoadScene(int sceneNumber)
    {
        target = 0;
        _progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneNumber);
        scene.allowSceneActivation = false;

        _loader_LoadingScreen.SetActive(true);
        ears.SetActive(false);
        videoBG.SetActive(false);
        Debug.Log("Pasta");
        //ears = GameObject.Find("Player's Ears");

        do 
        {
            Debug.Log(scene.progress);
            await Task.Delay(10000);
            //_progressBar.value = scene.progress;
            target = scene.progress;
          //(cam.GetComponent(typeof(AudioListener)) as AudioListener).enabled = false;
        }
        while (scene.progress < 0.9f);
        
        await Task.Delay(15000);
        
        scene.allowSceneActivation = true;
        await Task.Delay(500);
        _loader_LoadingScreen.SetActive(false);

        ears.SetActive(true);
        videoBG.SetActive(true);

    }

    void FixedUpdate()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, target, Time.maximumDeltaTime / 27  );
    }

}

/////////////////////////////END OF CODE///////////////////////////////////////

/////OLD METHOD//////