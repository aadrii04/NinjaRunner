using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaved_ForBrightness : AutoSavedSlider
{
    protected override void InternalValueChanged(float newValue)
    {
       // base.InternalValueChanged(newValue);
       Screen.brightness = newValue;
    }
}
