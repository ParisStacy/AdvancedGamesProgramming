using UnityEngine;
public class TuningVariables: MonoBehaviour {

    //Configurable Variables
    //Player
    public float playerSpeed = 5;


    //Structs
    public struct PlayerTuningVariables {
        public float speed;
    }

    //Declaring Structs
    public static PlayerTuningVariables playerTuning = new PlayerTuningVariables();

    void Update() {
        playerTuning.speed = playerSpeed;
    }
   
}