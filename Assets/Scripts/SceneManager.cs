using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public bool active;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!active) { return; }
        SceneBehavior();
    }

    protected virtual void SceneBehavior()
    {

    }

    public virtual void Activate()
    {
        active = true;
    }

    public virtual void Deactivate()
    {
        active = false;
    }

}
