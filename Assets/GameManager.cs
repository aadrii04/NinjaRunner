using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public void StartGame()
    {
        // por si es necesario
    }

    public void StopGame()
    {
        // cosas para cuando mueras
        playerController.DisableMechanics();
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // cosas para reiniciar la partida
        playerController.EnableMechanics();
        Time.timeScale = 1;
    }
}
