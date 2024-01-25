using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSavedSlider : MonoBehaviour
{
    [SerializeField] string playerPrefsKey;
    [SerializeField] float defaulValue = 0.5f;

    // Component Cache
    Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        slider.onValueChanged.AddListener(OnValueChanged);
        slider.value = PlayerPrefs.GetFloat(playerPrefsKey, defaulValue);
    }

    private void Start()
    {
        InternalValueChanged(slider.value);
    }

    void OnValueChanged(float newValue)
    {
        PlayerPrefs.SetFloat(playerPrefsKey, newValue);
        PlayerPrefs.Save();
        InternalValueChanged(newValue);
    }

    protected virtual void InternalValueChanged(float newValue)
    {
        Debug.Log("Hola");
    }
}
