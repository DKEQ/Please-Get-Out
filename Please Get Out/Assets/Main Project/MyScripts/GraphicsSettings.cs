using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
//////////////////////START OF SCRIPT///////////////////

////////////////////////////////////////////////////////

/////////////////VARRIBLES/////////////////////////////
public RenderPipelineAsset[] qualityLevels;
public TMP_Dropdown graphical_Settings_Dropdown;

/////////////////////////////////////////////////////////

///////////////FUNCTIONS////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        graphical_Settings_Dropdown.value = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void ChangeGraphicsLevel(int value)
{
    QualitySettings.SetQualityLevel(value);
    QualitySettings.renderPipeline = qualityLevels[value];
}
/////////////////////////////////////////////////////////////








}
/////////////////////END OF SCRIPT//////////////////
