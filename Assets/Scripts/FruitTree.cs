using System.Collections.Generic;
using UnityEngine;

public class FruitTree : MonoBehaviour
{

    public List<Cow> cows = new();

    public float fruitInterval;
    float fruitTimer;

    public bool hasLeftCow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fruitTimer = fruitInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (cows.Count == 0) {
            fruitTimer -= Time.deltaTime;
            if (fruitTimer <= 0)
            {
                InventoryManager.reference.GainFruit(1);
                fruitTimer += fruitInterval;
            }
        }
    }
}
