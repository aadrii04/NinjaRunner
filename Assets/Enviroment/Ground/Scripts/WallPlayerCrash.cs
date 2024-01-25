using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlayerCrash : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInChildren<PlayerController>().playerStates = PlayerController.PlayerStates.Crashed;
        }
    }
}
