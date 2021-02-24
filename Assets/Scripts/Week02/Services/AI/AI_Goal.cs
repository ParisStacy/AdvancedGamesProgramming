using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Goal : MonoBehaviour
{
    public bool blueGoal;

    private GameObject _ball;

    void Start() {
        _ball = ServicesLocator.GameManager.ball;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == _ball)
            ServicesLocator.EventManager.Fire(new GoalScored(blueGoal));
    }
}
