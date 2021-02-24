using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager
{
    private AI_Player[] _players;

    public void Start()
    {
        _players = ServicesLocator.GameManager.players;
        SpawnPlayers();
    }

    void Update()
    {
        
    }

    public void SpawnPlayers() {
        _players[0].Spawn(false, 1, false);
        _players[1].Spawn(true, 2, true);
    }

}
