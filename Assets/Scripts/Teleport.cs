using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform EndPortal;
    public GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = EndPortal.transform.position;
    }
}
