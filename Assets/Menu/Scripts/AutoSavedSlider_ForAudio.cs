using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AutoSavedSlider_ForAudio : AutoSavedSlider
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] string exposedParameterName;

    protected override void InternalValueChanged(float newValue)
    {
        mixer.SetFloat(exposedParameterName, LinearToDecibel(newValue));
    }

    // https://forum.unity.com/threads/how-to-calculate-db-correct.546128/
    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }
}
