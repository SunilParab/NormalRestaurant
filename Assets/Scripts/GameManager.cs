using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum Scene
    {
        Store,
        Farm,
        Sea,
        Eggland
    }

    public static Scene curScene;

    public static GameManager reference;

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
}
