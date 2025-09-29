using UnityEngine;

public class Cow : MonoBehaviour
{

    public int treeIndex;

    public void Start()
    {
        
    }

    public void Remove()
    {
        FarmManager.reference.trees[treeIndex].cows.Remove(this);

        if (transform.localPosition.x < 0) {
            FarmManager.reference.trees[treeIndex].hasLeftCow = false;
        }

        Destroy(gameObject);
    }

}
