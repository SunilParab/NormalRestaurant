using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum Scene
    {
        Store,
        Sea,
        Eggland,
        Farm
    }

    public static Scene curScene = Scene.Store;

    [SerializeField]
    Vector3[] positions;

    public static int customerNumber;
    [SerializeField] int maxCustomerNumber;

    public static GameManager reference;

    [SerializeField]
    GameObject cameraRef;

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

        if (customerNumber >= maxCustomerNumber) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScreen");
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int newScene = (int)curScene + 1;
            if (newScene == 4)
            {
                newScene = 0;
            }
            ChangeScene((Scene)newScene);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int newScene = (int)curScene - 1;
            if (newScene == -1)
            {
                newScene = 3;
            }
            ChangeScene((Scene)newScene);
        }




    }

    void ChangeScene(Scene newScene)
    {

        if (curScene == Scene.Store)
        {
            StoreManager.reference.Deactivate();
        }
        else if (curScene == Scene.Farm)
        {
            FarmManager.reference.Deactivate();
        }
        else if (curScene == Scene.Sea)
        {
            SeaManager.reference.Deactivate();
        }
        else if (curScene == Scene.Eggland)
        {
            EgglandManager.reference.Deactivate();
        }

        curScene = newScene;
        cameraRef.transform.position = positions[(int)newScene];

        if (newScene == Scene.Store)
        {
            StoreManager.reference.Activate();

        }
        else if (newScene == Scene.Farm)
        {
            FarmManager.reference.Activate();

        }
        else if (newScene == Scene.Sea)
        {
            SeaManager.reference.Activate();

        }
        else if (newScene == Scene.Eggland)
        {
            EgglandManager.reference.Activate();

        }
    }

}
