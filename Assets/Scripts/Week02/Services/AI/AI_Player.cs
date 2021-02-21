using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : MonoBehaviour
{
    private GameObject _ball;

    struct AIPlayerStruct {
        public float _speed;
        public bool _teamBlue;
        public bool _playerControlled;
        public bool _active;

        public Vector2 _movement;
    }

    private AIPlayerStruct thisPlayer;

    public void Spawn(bool playerControlled, float speed, bool teamBlue) {
        _ball = ServicesLocator.GameManager.ball;
        thisPlayer._playerControlled = playerControlled;
        thisPlayer._speed = speed;
        thisPlayer._teamBlue = teamBlue;
        thisPlayer._active = true;
        transform.position = new Vector3(2, 0, 0);
    }

    void Awake()
    {
        thisPlayer._active = false;
    }

    void Update()
    {
        //Update
        if (thisPlayer._playerControlled) UpdatePlayer();
        else UpdateAI();

        //Move (Towards Ball)
        transform.position += new Vector3(thisPlayer._movement.x, thisPlayer._movement.y, 0) * thisPlayer._speed * Time.deltaTime;

    }

    void UpdateAI() {
        //TODO: Behavior Tree
        thisPlayer._movement = towardsBall();
    }

    void UpdatePlayer() {
        thisPlayer._movement = ServicesLocator.InputManager._currentInput.moveVector;
    }

    Vector3 towardsBall() {
        return _ball.transform.position - transform.position;
    }
}
