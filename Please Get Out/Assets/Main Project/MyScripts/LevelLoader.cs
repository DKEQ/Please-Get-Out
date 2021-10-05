using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class LevelLoader : MonoBehaviour
{
/////////////////////START OF SCRIPT////////////////////////
//VARRIBLES
[SerializeField]
private Image fillSlider;//FillAmount Based progress bar

private AsyncOperation operation;

private Canvas loadingScreenCanvas;


private float target;
////////////////////////////////////////////////////////////


////////////////////FUNCTIONS///////////////////////////////
    
    
    private void Awake()//As soon as the scene starts
    {
        loadingScreenCanvas = GetComponentInChildren<Canvas>(true); //Get the component of the canvas child which is the loading screen and set it's set active to true
        DontDestroyOnLoad(gameObject); //Do not destroy this gameObject on load
    }

   
    

    public async void LoadScene(int sceneNumber)
    {
        UpdateProgressUI(0);
        target = 0;
        loadingScreenCanvas.gameObject.SetActive(true);
        await Task.Delay(20000);
        StartCoroutine(BeginLoad(sceneNumber));
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }

    private IEnumerator BeginLoad(int sceneNumber)
    {
        operation = SceneManager.LoadSceneAsync(sceneNumber);

        while   (!operation .   isDone)
        {
            //await Task.Delay(2000);
            target = operation.progress;
            float loadingProgress = Mathf.Clamp01(operation.progress);
            UpdateProgressUI(operation  .   progress);
            
            yield return null;
        }

        UpdateProgressUI(operation  .   progress);
        operation   =   null;
        loadingScreenCanvas.gameObject.SetActive(false);
    }

    private void UpdateProgressUI   (float progress)
    {
        fillSlider  .   fillAmount   =  progress;


    }

    void Update()
    {
        fillSlider.fillAmount = Mathf.MoveTowards(fillSlider.fillAmount, target, Time.maximumDeltaTime /45 );
    }































/////////////////////END OF SCRIPT////////////////////////
}
