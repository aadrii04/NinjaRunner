using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGraphicsSettings : MonoBehaviour
{
    [SerializeField] GameObject ligths;
    Toggle toggle;

    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        toggle.onValueChanged.AddListener(ChangeGraphics);
    }

    void ChangeGraphics(bool newValue)
    {
        if (newValue) { LigthsOn(); }
        else { LigthsOff(); }
    }
    void LigthsOn()
    {
        ligths.SetActive(true);
    }
    void LigthsOff()
    {
        ligths.SetActive(false);
    }
}
