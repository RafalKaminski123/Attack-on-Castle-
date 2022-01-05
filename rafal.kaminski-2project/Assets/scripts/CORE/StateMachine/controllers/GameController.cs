using SDA.UI;
using UnityEngine;

namespace SDA.Core
{
    public class GameController : BaseController
    {
        private WinState winState;
        private LoseState loseState;
        private GameState gameState;

        [SerializeField]
        private GameView gameView;
        [SerializeField]
        private SaveSystem saveSystem;

        protected override void InjectReferences()
        {
            winState = new WinState();
            loseState = new LoseState();
            gameState = new GameState(gameView, saveSystem);
        }

        protected override void Start()
        {
            base.Start();
            saveSystem.LoadData();
            ChangeState(gameState);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }

}
