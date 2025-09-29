using UnityEngine;

public class EnemyBoat : MonoBehaviour
{

    Vector3 targetPos; [SerializeField]

    public float moveSpeed;
    public float rotSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(PickPosition),0,5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (transform.position == targetPos) {
            PickPosition();
        }

        Vector2 direction = targetPos - transform.localPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * rotSpeed);

        transform.position += transform.right * Time.deltaTime * moveSpeed;
    }

    public void Die()
    {

    }

    void PickPosition()
    {
        targetPos = new(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
        //targetPos += new Vector3(60, 0, 0);
    }

}
