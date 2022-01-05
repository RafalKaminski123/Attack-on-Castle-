using SDA.UI;
using UnityEngine;

namespace SDA.Core
{
    public class MenuController : BaseController
    {
        #region STATES

        private MenuState menuState;

        #endregion

        #region SYSTEMS

        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private ExitPopup exitPopup;

        [SerializeField]
        private LoadingView loadingView;

        [SerializeField]
        private LoadingSystem loadingSystem;

        [SerializeField]
        private SaveSystem saveSystem;
        #endregion


        protected override void InjectReferences()
        {
            menuState = new MenuState(menuView, exitPopup, loadingView, loadingSystem, saveSystem);
        }

        protected override void Start()
        {
            base.Start();
            saveSystem.LoadData();
            ChangeState(menuState);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void StartGame()
        {
            Debug.Log("START GAME");
            //CHANGE SCENE TO GAME
        }
    }
}

