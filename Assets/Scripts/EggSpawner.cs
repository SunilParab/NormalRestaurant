using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject eggPrefab;

    [SerializeField]
    float spawnTimer = 1;
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
            SpawnEgg();
        }
    }

    void SpawnEgg()
    {
        GameObject newEgg = Instantiate(eggPrefab, new Vector3(), new Quaternion());
        newEgg.transform.SetParent(transform.parent);
        newEgg.transform.localPosition = MakeSpawnPos();
    }

    Vector3 MakeSpawnPos() {
        return new Vector3(Random.Range(-7,7),Random.Range(-4,4),0);
    }
}
