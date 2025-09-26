using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EggBasket : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            Destroy(collision.gameObject);
            InventoryManager.reference.GainEgg();
        }
    }

}
