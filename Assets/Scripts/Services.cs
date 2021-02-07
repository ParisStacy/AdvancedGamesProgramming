using UnityEngine;
//Service Locator

public static class Services {

    public static void InitializeServices(GameObject player) {
        EnemyManager.Initialize();
        InputManager.Initialize();
        PlayerManager.Initialize(player);
    }

    public static EnemyManager EnemyManager;
    public static InputManager InputManager;
    public static PlayerManager PlayerManager;
    public static GameManager GameManager;
}

public class EnemyManager {

    private Vector3 directionOfBall;

    public void Initialize() {

    }
    public void Update() {

    }
    public void Destruction() {

    }
    public void Tracking() {

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
