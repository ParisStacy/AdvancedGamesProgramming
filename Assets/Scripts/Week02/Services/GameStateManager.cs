using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    public FiniteStateMachine<GameStateManager> fsm;

    public void Start() {
        fsm = new FiniteStateMachine<GameStateManager>(this);
        fsm.TransitionTo<GameStart>();
        Debug.Log("FSM is up and running!");
    }

    public void Update() {
        fsm.Update();
    }

    private abstract class GameState : FiniteStateMachine<GameStateManager>.State {
        public override void OnEnter() {
            base.OnEnter();

            ServicesLocator.GameManager.panels[0].SetActive(false);
            ServicesLocator.GameManager.panels[1].SetActive(false);
            ServicesLocator.GameManager.panels[2].SetActive(false);

        }
    }

    private class InGame : GameState {

        string whichTeamWon = "";

        public override void OnEnter() {

            ServicesLocator.GameManager.panels[1].SetActive(true);
            Debug.Log("Set In Game active");

            base.OnEnter();
            ServicesLocator.EventManager.Fire(new GameStarted());

        }

        public override void Update() {
            base.Update();
        }

        public void onTeamWon(AGPEvent e) {
            var teamWon = (TeamWon)e;

            if (teamWon.blueWon) whichTeamWon = "Blue Team";
            else whichTeamWon = "Red Team";

            ServicesLocator.GameManager.WinnerText.text = whichTeamWon;

            TransitionTo<GameOver>();
        }

        public override void OnExit() {
            base.OnExit();
        }


    }

    private class GameStart : GameState {
        public override void OnEnter() {
            base.OnEnter();
            ServicesLocator.GameManager.panels[0].SetActive(true);
            Debug.Log("Game Started");
        }

        public override void Update() {
            base.Update();
            if (ServicesLocator.InputManager._currentInput.action01) {
                TransitionTo<InGame>();
            }
        }
    }

    private class GameOver : GameState {
        public override void OnEnter() {
            base.OnEnter();
            ServicesLocator.GameManager.panels[2].SetActive(true);
        }
        public override void Update() {
            base.Update();
            if (ServicesLocator.InputManager._currentInput.action01) {
                TransitionTo<GameStart>();
            }
        }
    }

}



