using UnityEngine;

public class StoreManager : SceneManager
{

    public static StoreManager reference;

    public FoodThrower foodThrower;

    void Awake()
    {
        reference = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Activate()
    {
        base.Activate();
        foodThrower.Activate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        foodThrower.Deactivate();
    }
}
