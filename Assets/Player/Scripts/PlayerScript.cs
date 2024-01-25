using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 dir;
    private void Start()
    {
        dir = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dir == Vector3.forward) { dir = Vector3.right; }
            else { dir = Vector3.forward; }
        }
        float movingPlayer = speed * Time.deltaTime;

        transform.Translate(dir * movingPlayer);
    }
}
