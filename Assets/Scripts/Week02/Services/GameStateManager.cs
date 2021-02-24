using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private abstract class GameState : FiniteStateMachine<GameStateManager>.State {
        public override void OnEnter() {
            base.OnEnter();
            /*
            Context.titleScreen.SetActive(false);
            Context.inGame.gameObject.SetActive(false);
            Context.gameOver.gameObject.SetActive(false);
            */

            for (int i = 0; i < ServicesLocator.GameManager.panels.Length - 1; i++) {
                ServicesLocator.GameManager.panels[i].SetActive(false);
            }

        }
    }

    private class InGame : GameState {

        string whichTeamWon = "";

        public override void OnEnter() {

            ServicesLocator.GameManager.panels[1].SetActive(true);

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



