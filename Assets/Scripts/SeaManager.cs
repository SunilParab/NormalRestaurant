using System.Collections.Generic;
using UnityEngine;

public class SeaManager : SceneManager
{

    public static SeaManager reference;

    public List<PlayerBoat> playerBoats = new List<PlayerBoat>();
    [SerializeField] GameObject playerPrefab;

    void Awake()
    {
        reference = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Activate()
    {
        base.Activate();
        foreach (PlayerBoat curBoat in playerBoats)
        {
            curBoat.Activate();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        foreach (PlayerBoat curBoat in playerBoats)
        {
            curBoat.Deactivate();
        }
    }

    public void SpawnPlayer()
    {

        if (Physics2D.OverlapCircle(transform.position, 0.4f) != null)
        {
            Invoke(nameof(SpawnPlayer), 0.1f);
            return;
        }

        PlayerBoat cur = Instantiate(playerPrefab, transform).GetComponent<PlayerBoat>();
        if (active)
        {
            cur.Activate();
        }
        playerBoats.Add(cur);
    }
    
}
