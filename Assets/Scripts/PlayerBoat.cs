using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBoat : MonoBehaviour
{

    [SerializeField] public bool active;

    bool held = false;
    Rigidbody2D rb;
    [SerializeField] Cooldown cd;

    public float forceConstant;
    [SerializeField]
    float maxForce;

    bool hasProduct = false;
    public int productSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (held && (Input.GetMouseButtonUp(0) || active == false))
        {
            //Get mouse position
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Vector3 worldPositionInput = new Vector3(screenPosition.x, screenPosition.y, 0);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(worldPositionInput);

            Vector2 forceVector = transform.position - worldPosition;

            if (forceVector.magnitude > maxForce)
            {
                forceVector = forceVector.normalized * maxForce;
            }

            rb.AddForce(forceVector * forceConstant, ForceMode2D.Impulse);

            held = false;
            cd.StartCooldown();
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

    void OnMouseDown()
    {
        if (!active || cd.CheckCooldown()) { return; }

        held = true;
    }

    public void Die()
    {
        SeaManager.reference.playerBoats.Remove(this);
        SeaManager.reference.SpawnPlayer();

        Destroy(gameObject);
    }

    public void GetProduct()
    {
        hasProduct = true;
    }

    public void DeliverProduct()
    {
        if (hasProduct) {
            hasProduct = false;
            InventoryManager.reference.GainFish(productSize);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LoadZone")) {
            GetProduct();
        }
        
        else if (collision.CompareTag("DropZone")) {
            DeliverProduct();
        }
    }

}
