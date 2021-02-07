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

//Enemy Manager
public class EnemyManager {
    //Enemy Struct
    private struct enemyStruct {
        public GameObject enemyObject;
        public Vector3 direction;
    }

    //Declare Struct array
    private enemyStruct[] _enemies = new enemyStruct[TuningVariables.EnemyTuning.count];

    private GameObject _ball;

    //Initialize
    public void Initialize(GameObject ball) {
        Debug.Log("Initializing Enemies...");

        _ball = ball;

        //For each enemyStruct in _enemies, instantiate and assign an enemy prefab to it through the game manager
        for(int i=0; i <= _enemies.Length; i++) {
            GameObject newEnemy;
            newEnemy = Services.GameManager.SpawnEnemy();
            _enemies[i].enemyObject = newEnemy;
        }
    }

    public void Update() {

        //Track Ball
        Tracking();
        //All enemies in _enemies, move towards ball
        foreach(enemyStruct n in _enemies) {
            n.enemyObject.transform.position += n.direction * Time.deltaTime * TuningVariables.EnemyTuning.speed;
        }

    }

    public void Destruction() {
    }

    public void Tracking() {
        //Give each enemy in _enemies a direction towards the ball
        for (int i = 0; i < _enemies.Length - 1; i++) {
            _enemies[i].direction = _enemies[i].enemyObject.transform.position - _ball.transform.position;
        }
    }
}

public class InputManager : MonoBehaviour {

    //Player Input as a struct
    public struct PlayerInput {
        public float xMove, yMove;
        public bool interact;
    }

    public PlayerInput playerInput = new PlayerInput();


    public void Initialize() {

    }

    //Update Player Input
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

    //Update Player Speed / Movement by accessing Input
    public void Update() {

        float playerSpeed = TuningVariables.playerTuning.speed;

        Vector2 playerMove = new Vector2(Services.InputManager.playerInput.xMove, Services.InputManager.playerInput.yMove);

        playerObject.transform.position += new Vector3(playerMove.x, playerMove.y, 0) * Time.deltaTime * playerSpeed;
    }
}
