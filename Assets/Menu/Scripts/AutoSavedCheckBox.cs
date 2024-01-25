using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSavedCheckBox : MonoBehaviour
{
    [SerializeField] string playerPrefsKey;
    [SerializeField] bool defaultValue = false;

    // Component Cache
    Toggle toggle;

    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        toggle.onValueChanged.AddListener(OnValueChanged);
        toggle.isOn = PlayerPrefs.GetInt(playerPrefsKey, defaultValue ? 1 : 0) == 1;
    }

    private void Start()
    {
        InternalValueChanged(toggle.isOn);
    }

    void OnValueChanged(bool newValue)
    {
        PlayerPrefs.SetInt(playerPrefsKey, newValue ? 1 : 0);
        PlayerPrefs.Save();
        InternalValueChanged(newValue);
    }

    protected virtual void InternalValueChanged(bool newValue)
    {
        Debug.Log("Hola");
    }
}

