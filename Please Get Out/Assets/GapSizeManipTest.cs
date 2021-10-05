using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class GapSizeManipTest : MonoBehaviour
{
    public GameObject This;

    public float GapGrowthAndShrinkRate = 1f;

    public int delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        var outlinableToUse = GetComponent<Outlinable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
