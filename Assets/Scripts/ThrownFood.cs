using UnityEngine;

public class ThrownFood : MonoBehaviour
{

    public InventoryManager.ItemType type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0,5,80,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0, 0, Time.deltaTime * 10));

        if (transform.position.z > 100) {
            Destroy(gameObject);
        }
    }

    public void SetValues(InventoryManager.ItemType type)
    {
        this.type = type;
    }

}
