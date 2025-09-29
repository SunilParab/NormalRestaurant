using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    [SerializeField]
    InventoryManager.ItemType preference;

    int hunger = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeValues();
        GameManager.customerNumber++;
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

        GameObject icon = Instantiate(InventoryManager.reference.icons[(int)preference], transform);
        icon.transform.Translate(0,0.5f,-0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Eat(other.GetComponent<ThrownFood>().type);
            Destroy(other.gameObject);
        }
    }

    void Eat(InventoryManager.ItemType foodType)
    {
        if (foodType == preference)
        {
            hunger--;
            if (hunger <= 0)
            {
                Destroy(gameObject);
                GameManager.customerNumber--;
            }
        }
    }

}
