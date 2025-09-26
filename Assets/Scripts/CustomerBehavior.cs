using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{

    InventoryManager.ItemType preference;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeValues();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeValues()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                preference = InventoryManager.ItemType.Fish;
                break;
            case 1:
                preference = InventoryManager.ItemType.Egg;
                break;
            case 2:
                preference = InventoryManager.ItemType.Fruit;
                break;
        }
        
        //TODO pick random face

    }

}
