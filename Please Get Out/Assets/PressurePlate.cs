using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isApplyingPressure;
    public string ActivationString;
    public string DeactivationString;
    public GameObject[] GOwAnims;
   // private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        isApplyingPressure = false;
        Debug.Log("Pressure OFF");
//        rb.GetComponent<Collider>();
       // GOwAnims = GetComponent<AnimationClip>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == ActivationString)
        {
            isApplyingPressure = true;
            Debug.Log("Contact");
            
            
        }
        else
        {
            {
            isApplyingPressure = false;
            Debug.Log("Pressure OFF");
            }
        }

        }
}
