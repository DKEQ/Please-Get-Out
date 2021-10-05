using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBackLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter(Collider chkCol){
        if(chkCol.tag == "PrevLevel"){
            Debug.Log ("Collision Detected Changing Scene");
            SceneManager.LoadScene("Level 1");
        }
    }
}
