using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] InputActionReference pauseGame;
    bool alreadyPaused;

    private void OnEnable()
    {
        pauseGame.action.performed += PauseGame;
        pauseGame.action.Enable();
    }
    private void OnDisable()
    {
        pauseGame.action.performed -= PauseGame;
        pauseGame.action.Disable();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (!alreadyPaused) {         
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            alreadyPaused = true; }
        else {
            alreadyPaused = false;
            ResumeGame(); }
    }

    public void ResumeGame()
    {
        Time .timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
