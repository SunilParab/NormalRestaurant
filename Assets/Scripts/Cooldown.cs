using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public float maxCooldown;
    float curCooldown;
    bool onCooldown;

    GameObject child;
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        sr = child.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (curCooldown > 0)
        {

            child.transform.localScale = new(curCooldown/maxCooldown,1,1);

            curCooldown -= Time.deltaTime;
            if (curCooldown <= 0)
            {
                curCooldown = 0;
                onCooldown = false;
                sr.enabled = false;
            }
        }
    }

    public void StartCooldown()
    {
        curCooldown = maxCooldown;
        onCooldown = true;

        sr.enabled = true;
    }

    public bool CheckCooldown()
    {
        return onCooldown;
    }

}
