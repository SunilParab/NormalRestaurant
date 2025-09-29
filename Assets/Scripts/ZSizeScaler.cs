using UnityEngine;

public class ZSizeScaler : MonoBehaviour
{

    float startSize;

    void Start()
    {
        startSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newSize = startSize * (100 - transform.position.z) / 100;
        transform.localScale = new Vector3(newSize, newSize, newSize);
    }
}
