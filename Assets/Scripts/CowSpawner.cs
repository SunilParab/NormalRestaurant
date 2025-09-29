using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{

    public float cowInterval;
    float cowTimer;

    [SerializeField] Sprite[] cowSprites;
    [SerializeField] GameObject cowPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cowTimer = cowInterval;
    }

    // Update is called once per frame
    void Update()
    {
        cowTimer -= Time.deltaTime;
        if (cowTimer <= 0)
        {
            TrySpawnCow();
            cowTimer += cowInterval;
        }
    }

    void TrySpawnCow()
    {
        List<FruitTree> possibleTrees = new List<FruitTree>(FarmManager.reference.trees);

        while (possibleTrees.Count > 0)
        {
            int index = Random.Range(0, possibleTrees.Count);
            if (possibleTrees[index].cows.Count < 2)
            {
                if (possibleTrees[index].hasLeftCow)
                {
                    SpawnCow(index, false);
                    return;
                }
                else
                {
                    if (possibleTrees[index].cows.Count > 0)
                    {
                        SpawnCow(index, true);
                        return;
                    }
                    else
                    {
                        SpawnCow(index, Random.Range(0, 2) > 0);
                        return;
                    }
                }
            }
            else
            {
                possibleTrees.RemoveAt(index);
            }
        }

    }

    void SpawnCow(int treeIndex, bool isLeft)
    {
        GameObject curCow = Instantiate(cowPrefab, FarmManager.reference.trees[treeIndex].transform);
        if (isLeft)
        {
            curCow.transform.localPosition = new(-1.5f, -3, 0);
            FarmManager.reference.trees[treeIndex].hasLeftCow = true;
        }
        else
        {
            curCow.transform.localPosition = new(1.5f, -3, 0);
        }

        curCow.GetComponent<Cow>().treeIndex = treeIndex;

        FarmManager.reference.trees[treeIndex].cows.Add(curCow.GetComponent<Cow>());

        curCow.GetComponent<SpriteRenderer>().sprite = cowSprites[Random.Range(0, cowSprites.Length)];

    }

}
