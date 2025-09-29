using UnityEngine;

public class BoatKiller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBoat")) {
            collision.GetComponent<PlayerBoat>().Die();
        }
    }
}
