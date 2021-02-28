using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public Team white;
    public Team black;

    void Start()
    {
        white.white = true;
        black.white = false;



    }

    void Update()
    {
        
    }
}
