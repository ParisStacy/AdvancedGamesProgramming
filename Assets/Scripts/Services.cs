using UnityEngine;
//Service Locator

public static class Services {

    public static void InitializeServices(GameObject player, GameObject ball) {
        EnemyManager.Initialize(ball);
        InputManager.Initialize();
        PlayerManager.Initialize(player);
    }

    public static EnemyManager EnemyManager;
    public static InputManager InputManager;
    public static PlayerManager PlayerManager;
    public static GameManager GameManager;
}

public class EnemyManager {

    private struct enemyStruct {
        public GameObject enemyObject;
        public Vector3 direction;
    }

    private enemyStruct[] _enemies = new enemyStruct[TuningVariables.EnemyTuning.count];

    private GameObject _ball;

    public void Initialize(GameObject ball) {
        _ball = ball;

        foreach(enemyStruct n in _enemies) {
            GameObject newEnemy;
            Services.GameManager.SpawnEnemy(out newEnemy);
            n.enemyObject = newEnemy;
        }
    }

    public void Update() {
        Tracking();
        foreach(enemyStruct n in _enemies) {
            n.enemyObject.transform.position += n.direction * Time.deltaTime * TuningVariables.EnemyTuning.speed;
        }
    }

    public void Destruction() {

    }
    public void Tracking() {
        foreach(enemyStruct n in _enemies) {
            n.direction = n.enemyObject.transform.position - _ball.transform.position;
        }
    }
}

public class InputManager : MonoBehaviour {

    public struct PlayerInput {
        public float xMove, yMove;
        public bool interact;
    }

    public PlayerInput playerInput = new PlayerInput();

    public void Initialize() {

    }

    public void Update() {

        playerInput.xMove = Input.GetAxis("Horizontal");
        playerInput.yMove = Input.GetAxis("Vertical");

        playerInput.interact = Input.GetKeyDown(KeyCode.Space);

    }
}

public class PlayerManager {

    private GameObject playerObject;

    public void Initialize(GameObject player) {
        playerObject = player;
    }

    public void Update() {

        float playerSpeed = TuningVariables.playerTuning.speed;

        Vector2 playerMove = new Vector2(Services.InputManager.playerInput.xMove, Services.InputManager.playerInput.yMove);

        playerObject.transform.position += new Vector3(playerMove.x, playerMove.y, 0) * Time.deltaTime * playerSpeed;
    }
}
