using UnityEngine;

public class FoodThrower : MonoBehaviour
{

    int curSlot;
    [SerializeField]
    GameObject[] itemPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check number keys to set slot

        //Check click and current slot
            //Throw()
    }

    void Throw()
    {
        //instantiate object based on curSlot at mouse pos plus itemStartZ
        //object handles its movement
    }

}
