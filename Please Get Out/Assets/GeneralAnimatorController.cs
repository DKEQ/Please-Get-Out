using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAnimatorController : MonoBehaviour
{
    public Animator anim;
    //public GameObject[] levelKey;
    public PressurePlate keyScript;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //levelKey = GetComponent<UnityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(isApplyingPressure)
        // {

        // }
    }
}
