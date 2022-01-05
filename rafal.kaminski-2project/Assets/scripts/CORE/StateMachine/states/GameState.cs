using System.Collections;
using System.Collections.Generic;
using SDA.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SDA.Core
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private SaveSystem saveSystem;

        public GameState(GameView gameView, SaveSystem saveSystem)
        {
            this.gameView = gameView;
            this.saveSystem = saveSystem;
        }

        public override void InitializeState()
        {
            base.InitializeState();
            var currency = saveSystem.GetSave().currency;
            gameView.UpdateCurrency(currency);
            currency += 200;
            saveSystem.GetSave().currency = currency;
            saveSystem.SaveData();
            gameView.ShowView();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            Debug.Log("GAME STATE");
        }

        public override void DestroyState()
        {
            base.DestroyState();
        }
    }
}
