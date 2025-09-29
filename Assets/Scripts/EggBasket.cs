using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EggBasket : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] Cooldown cd;
    float force = 10;

    bool active = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Deactivate();
    }

    void Update()
    {
        if (!active)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && !cd.CheckCooldown())
        {
            //Get mouse position
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Vector3 worldPositionInput = new Vector3(screenPosition.x, screenPosition.y, 0);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(worldPositionInput);

            Vector2 forceVector = worldPosition - transform.position;

            rb.AddForce(forceVector.normalized * force, ForceMode2D.Impulse);

            cd.StartCooldown();

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Destroy(collision.gameObject);
            if (active)
            {
                InventoryManager.reference.GainEgg(1);
            }
        }
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

}
