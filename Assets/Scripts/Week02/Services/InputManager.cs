using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {

    public struct currentInput {
        public Vector2 moveVector;
        public bool action01;
    }

    public currentInput _currentInput;

    public void Start() {

    }

    public void Update() {

        var a = Input.GetAxis("Horizontal");
        var b = Input.GetAxis("Vertical");

        _currentInput.moveVector = new Vector2(a, b);
        _currentInput.action01 = Input.GetKeyDown(KeyCode.Space);

    }
}
