using UnityEngine;

public class GrapplerPiece : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GrapplerManager.instance.TakePiece();
            gameObject.SetActive(false);
        }
    }
}
