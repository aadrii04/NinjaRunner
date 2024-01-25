using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] GameObject cameraTarget;

    private void Update()
    {
        transform.transform.position = cameraTarget.transform.position;
    }
}
