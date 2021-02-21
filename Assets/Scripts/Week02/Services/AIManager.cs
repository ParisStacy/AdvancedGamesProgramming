using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager
{
    private AI_Player[] _players;

    public void Start()
    {
        _players = ServicesLocator.GameManager.players;

        _players[0].Spawn(false, 2, false);
        _players[1].Spawn(true, 3, false);
    }

    void Update()
    {
        
    }
}
