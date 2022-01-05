using SDA.UI;

namespace SDA.Core
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private ExitPopup exitPopup;
        private LoadingView loadingView;
        private LoadingSystem loadingSystem;
        private SaveSystem saveSystem;

        public MenuState(MenuView menuView, ExitPopup exitPopup, LoadingView loadingView,
            LoadingSystem loadingSystem, SaveSystem saveSystem)
        {
            this.menuView = menuView;
            this.exitPopup = exitPopup;
            this.loadingView = loadingView;
            this.loadingSystem = loadingSystem;
            this.saveSystem = saveSystem;
        }

        public override void InitializeState()
        {
            base.InitializeState();
            menuView.InitializeView();
            exitPopup.InitializePopup();
            menuView.ShowView();

            menuView.OnStartButtonClicked_AddListener(StartGame);
            menuView.OnExitButtonClicked_AddListener(exitPopup.ShowView);
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void DestroyState()
        {
            menuView.HideView();
            base.DestroyState();
        }

        private void StartGame()
        {
            var levelIndex = saveSystem.GetSave().levelIndex;
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(levelIndex);
        }
    }
}
