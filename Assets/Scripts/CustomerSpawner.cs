using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject customerPrefab;

    [SerializeField]
    float spawnTimer = 5;
    float curTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curTimer = spawnTimer;
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
        Instantiate(customerPrefab, MakeSpawnPos(), new Quaternion());
    }

    Vector3 MakeSpawnPos() { //TODO
        return new Vector3();
    }

}
