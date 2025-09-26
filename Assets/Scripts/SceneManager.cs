using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public bool Active;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!Active) { return; }
        SceneBehavior();
    }

    protected virtual void SceneBehavior()
    {
        
    }

}
