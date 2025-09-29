using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject customerPrefab;

    [SerializeField]
    float spawnTimer = 5;
    float curTimer;

    [SerializeField] Sprite[] customerSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curTimer = spawnTimer;
        SpawnCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        curTimer -= Time.deltaTime;
        if (curTimer < 0)
        {
            curTimer += spawnTimer;
            SpawnCustomer();
        }
    }

    void SpawnCustomer()
    {
        Instantiate(customerPrefab, MakeSpawnPos(), new Quaternion()).GetComponent<SpriteRenderer>().sprite = customerSprites[Random.Range(0,customerSprites.Length)];
    }

    Vector3 MakeSpawnPos() {
        return new Vector3(Random.Range(-4,4),Random.Range(-2,2),Random.Range(10,50));
    }

}
