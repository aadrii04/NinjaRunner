using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector3 direccionActual = Vector3.forward;

    void Update()
    {
        transform.Translate(-direccionActual * velocidad * Time.deltaTime);
    }
}
