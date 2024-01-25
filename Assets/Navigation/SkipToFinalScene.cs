using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkipToFinalScene : MonoBehaviour
{

    private void Update()
    {
        if(Keyboard.current.tabKey.wasPressedThisFrame)
        {
            LoadingScreen.LoadScene("WinScene");
        }
    }
}
