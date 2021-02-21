using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Configuration")]
    public Text ScoreText;
    public GameObject ball;
    public AI_Player[] players;

    [Header("Tuning: Player")]
    public float playerSpeed;
    [Header("Tuning: Enemy")]
    public float baseEnemySpeed;

    private int _blueScore;
    private int _redScore;

    void Awake()
    {
        //Initialize Services
        ServicesLocator.GameManager = this;
        ServicesLocator.InitializeServices();




    }

    void Update()
    {
        //Update ScoreText
        ScoreText.text = _blueScore + " : " + _redScore;
        //Update Services
        UpdateServices();

    }

    void UpdateServices()
    {
        ServicesLocator.InputManager.Update();
    }

}
