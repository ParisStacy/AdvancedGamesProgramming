using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerObject;

    void Start()
    {
        Services.GameManager = this;
        Services.EnemyManager = new EnemyManager();
        Services.InputManager = new InputManager();
        Services.PlayerManager = new PlayerManager();

        Services.InitializeServices(PlayerObject);
    }

    void Update()
    {
        Services.EnemyManager.Update();
        Services.InputManager.Update();
        Services.PlayerManager.Update();
    }
}
