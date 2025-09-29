using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager reference;

    public enum ItemType
    {
        Fish,
        Egg,
        Fruit
    }

    public GameObject[] icons;

    //UI reference
    [SerializeField]
    TextMeshProUGUI amountText;

    //Food items
    [SerializeField] int fish = 0;
    [SerializeField] int eggs = 0;
    [SerializeField] int fruit = 0;

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
        amountText.text = "Fish: " + fish + "\nEggs: " + eggs + "\nFruit: " + fruit;
    }

    public void GainFish(int value)
    {
        fish += value;
    }

    public void GainEgg(int value)
    {
        eggs += value;
    }

    public void GainFruit(int value)
    {
        fruit += value;
    }

    public bool SpendFish(int value)
    {
        if (fish <= 0) {
            return false;
        }
        fish -= value;
        return true;
    }

    public bool SpendEgg(int value)
    {
        if (eggs <= 0) {
            return false;
        }
        eggs -= value;
        return true;
    }

    public bool SpendFruit(int value)
    {
        if (fruit <= 0) {
            return false;
        }
        fruit -= value;
        return true;
    } 

}
