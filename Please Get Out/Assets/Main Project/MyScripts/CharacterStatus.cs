using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] status = new GameObject[4];

    public GameObject thePlayerController;
    public PlayerController playerControllerScript;

    //private int arrayIndex = 0;
    void Start()
    {
        playerControllerScript = thePlayerController.GetComponent<PlayerController>();
        //foreach(GameObject go in status)
        //{
          //  go.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {   
        

        //when character sprints
        if(thePlayerController.GetComponent<PlayerController>().isSprinting())
        {
            Debug.Log("Wow you can run!");
            status[2].SetActive(true);
            status[0].SetActive(false);
            status[1].SetActive(false);
            status[3].SetActive(false);

        }
        else if (thePlayerController.GetComponent<PlayerController>().isWalking())
        {
            status[0].SetActive(false);
            status[1].SetActive(true);
            status[2].SetActive(false);
            status[3].SetActive(false);
        }


        //when character walks
        else if(thePlayerController.GetComponent<PlayerController>().isCrouching())
        {
            Debug.Log("Crouching");
            status[3].SetActive(true);
            status[0].SetActive(false);
            status[1].SetActive(false);
            status[2].SetActive(false);
        }
        else
        {
            status[0].SetActive(true);
            status[1].SetActive(false);
            status[2].SetActive(false);
            status[3].SetActive(false);


        }

        




    }
}
