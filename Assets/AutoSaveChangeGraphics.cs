
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaveChangeGraphics : AutoSavedCheckBox
{
    public enum GraphicsToChange { lightsOn, lightsOff };
    [SerializeField] GameObject ligths;
 
    [SerializeField] GraphicsToChange graphicsToChange = GraphicsToChange.lightsOff;

    private void Start()
    {
        ligths = GameObject.Find("SkyandFogVolume");
    }
    protected override void InternalValueChanged(bool newValue)
    {
        //AxisState axisStateToChange =
        //        axisToInvert == AxisToInvert.X ? 
        //        cinemachineFreeLook.m_XAxis :
        //        cinemachineFreeLook.m_YAxis;

        //axisStateToChange.m_InvertInput = newValue;

        if(graphicsToChange == GraphicsToChange.lightsOff) { ligths.SetActive(false); }
        else { ligths.SetActive(true); }
    }
}
