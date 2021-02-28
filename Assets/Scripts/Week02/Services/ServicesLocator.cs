using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServicesLocator
{
    public static void InitializeServices() {
        //Initialize
        ServicesLocator.GameStateManager = new GameStateManager();
        ServicesLocator.AIManager = new AIManager();
        ServicesLocator.EventManager = new EventManager();
        ServicesLocator.InputManager = new InputManager();
        //Run Startup
        InputManager.Start();
        AIManager.Start();
        GameStateManager.Start();
    }

    public static GameManager GameManager;
    public static GameStateManager GameStateManager;
    public static AIManager AIManager;
    public static EventManager EventManager;
    public static InputManager InputManager;

}
