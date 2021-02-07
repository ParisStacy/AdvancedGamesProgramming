using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject BallObject;

    public GameObject enemyPrefab;

    void Start()
    {
        Services.GameManager = this;
        Services.EnemyManager = new EnemyManager();
        Services.InputManager = new InputManager();
        Services.PlayerManager = new PlayerManager();

        Services.InitializeServices(PlayerObject,BallObject);
    }

    void Update()
    {
        Services.EnemyManager.Update();
        Services.InputManager.Update();
        Services.PlayerManager.Update();
    }

    public void SpawnEnemy(out GameObject enemy) {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(0,1,7), Quaternion.identity);
        enemy = newEnemy;
    }
}
