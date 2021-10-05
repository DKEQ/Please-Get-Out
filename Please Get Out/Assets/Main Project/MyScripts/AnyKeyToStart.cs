using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToStart : MonoBehaviour {
        public int SameLevel = 0;
 // Update is called once per frame
 void Update () {
  
  //if press any key jump to gameplay scene
  if(Input.anyKeyDown)
  {
   Invoke("LoadScene",0.5f);
   
   
  }
 
 }
 
 void LoadScene()
 {
  //load gameplay scene
    Debug.Log ("Refreshing Scene");
            SceneManager.LoadScene(SameLevel);
 }
 
}
