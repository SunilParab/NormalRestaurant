using UnityEngine;
using UnityEngine.InputSystem;

public class EgglandManager : SceneManager
{

    public static EgglandManager reference;

    public static GameObject eggBasket;

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

    protected override void SceneBehavior()
    {
        //Get mouse position
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector3 worldPositionInput = new Vector3(screenPosition.x, screenPosition.y, 0);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(worldPositionInput);

        eggBasket.transform.position = worldPosition;

    }


}
