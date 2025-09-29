using UnityEngine;
using System.Collections.Generic;

public class FarmManager : SceneManager
{

    public static FarmManager reference;

    public SharkController sharkController;
    public List<FruitTree> trees;

    void Awake()
    {
        reference = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Deactivate();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Activate()
    {
        base.Activate();
        sharkController.Activate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        sharkController.Deactivate();
    }
    
}
