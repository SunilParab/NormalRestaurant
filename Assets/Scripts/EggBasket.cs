using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EggBasket : MonoBehaviour
{

    Rigidbody2D rb;
    Collider2D col;
    float force = 10;

    bool active = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        Deactivate();
    }

    void Update()
    {
        if (!active)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Get mouse position
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Vector3 worldPositionInput = new Vector3(screenPosition.x, screenPosition.y, 0);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(worldPositionInput);

            Vector2 forceVector = worldPosition - transform.position;

            rb.AddForce(forceVector.normalized * force, ForceMode2D.Impulse);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Destroy(collision.gameObject);
            if (active)
            {
                InventoryManager.reference.GainEgg();
            }
        }
    }

    public void Activate()
    {
        //col.enabled = true;
        active = true;
    }

    public void Deactivate()
    {
        //col.enabled = false;
        active = false;
    }

}
