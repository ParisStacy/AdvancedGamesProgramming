using UnityEngine;
public class TuningVariables: MonoBehaviour {

    //Configurable Variables
    //Player
    public float playerSpeed = 5;
    //Enemy
    public int enemyNumber = 1;
    public float enemySpeed = 5;

    //Structs
    public struct PlayerTuningVariables {
        public float speed;
    }
    public struct EnemyTuningVariables {
        public int count;
        public float speed;
    }

    //Declaring Structs
    public static PlayerTuningVariables playerTuning = new PlayerTuningVariables();
    public static EnemyTuningVariables EnemyTuning = new EnemyTuningVariables();

    void Update() {
        playerTuning.speed = playerSpeed;

        EnemyTuning.count = enemyNumber;
        EnemyTuning.speed = enemySpeed;
    }
   
}