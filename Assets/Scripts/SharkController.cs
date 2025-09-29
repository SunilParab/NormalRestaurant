using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class SharkController : MonoBehaviour
{

    InputAction moveAction;

    bool active;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    bool jumping;
    bool goingUp;

    float startY;
    [SerializeField] float jumpHeight;

    [SerializeField] Cooldown cd;
    Collider2D col;
    [SerializeField] Sprite[] sprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        startY = transform.localPosition.y;
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (!active || cd.CheckCooldown() || jumping)
        {
            moveValue = Vector2.zero;
        }

        if (moveValue.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveValue.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (!jumping)
        {
            transform.Translate(moveValue * Time.deltaTime * speed);
            if (Input.GetKeyDown(KeyCode.Space) && active && !cd.CheckCooldown())
            {
                jumping = true;
                goingUp = true;
                col.enabled = true;
            }
        }
        else
        {
            transform.Translate(-transform.right * transform.localScale.x * Time.deltaTime * speed);
            if (goingUp)
            {
                transform.Translate(transform.up * Time.deltaTime * jumpSpeed);
                if (transform.localPosition.y > startY + jumpHeight)
                {
                    transform.localPosition = new(transform.localPosition.x, startY + jumpHeight, 0);
                    goingUp = false;
                }
            }
            else
            {
                transform.Translate(-transform.up * Time.deltaTime * jumpSpeed);
                if (transform.localPosition.y < startY)
                {
                    transform.localPosition = new(transform.localPosition.x, startY, 0);
                    jumping = false;
                    col.enabled = false;
                    cd.StartCooldown();
                }
            }
        }

        if (transform.localPosition.x > 7)
        {
            transform.localPosition = new(7, transform.localPosition.y, 0);
        }
        else if (transform.localPosition.x < -7)
        {
            transform.localPosition = new(-7, transform.localPosition.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cow"))
        {
            collision.GetComponent<Cow>().Remove();
            Destroy(collision.gameObject);
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
