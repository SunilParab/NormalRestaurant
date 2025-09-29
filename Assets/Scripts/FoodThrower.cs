using UnityEngine;
using UnityEngine.InputSystem;

public class FoodThrower : MonoBehaviour
{

    int curSlot;
    [SerializeField]
    GameObject[] itemPrefabs;

    bool active = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!active) {return;}

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curSlot = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curSlot = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curSlot = 3;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }

    }

    void Throw()
    {


        switch (curSlot)
        {
            case 0:
                if (!InventoryManager.reference.SpendFish(1))
                {
                    return;
                }
                break;
            case 1:
                if (!InventoryManager.reference.SpendEgg(1))
                {
                    return;
                }
                break;
            case 2:
                if (!InventoryManager.reference.SpendFruit(1))
                {
                    return;
                }
                break;
        }

        //Get mouse position
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector3 worldPositionInput = new Vector3(screenPosition.x, screenPosition.y, 0);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(worldPositionInput);

        GameObject itemRef = Instantiate(itemPrefabs[curSlot], worldPosition, new Quaternion());
        itemRef.GetComponent<ThrownFood>().SetValues((InventoryManager.ItemType)curSlot);

    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

}
