using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager reference;

    public enum ItemType
    {
        Fish,
        Egg,
        Fruit
    }

    //UI reference

    //Food items
    int fish = 0;
    int eggs = 0;
    int fruit = 0;

    void Awake()
    {
        reference = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GainEgg()
    {
        eggs++;
    }

    
}
