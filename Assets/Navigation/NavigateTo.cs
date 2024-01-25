using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateTo : MonoBehaviour
{
    public void LoadScene(string sceneToLoad)
    {
        LoadingScreen.LoadScene(sceneToLoad);
    }

    public void UnLoadScene(string sceneToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }
}
