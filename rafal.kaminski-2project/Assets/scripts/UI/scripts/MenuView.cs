using UnityEngine;
using UnityEngine.Events;

namespace SDA.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private CustomButton startGameButton;

        [SerializeField]
        private CustomButton optionsButton;

        [SerializeField]
        private CustomButton exitButton;

        public void InitializeView()
        {
            startGameButton.onMouseEnter.AddListener(() => ScaleUp(startGameButton));
            optionsButton.onMouseEnter.AddListener(() => ScaleUp(optionsButton));
            exitButton.onMouseEnter.AddListener(() => ScaleUp(exitButton));

            startGameButton.onMouseExit.AddListener(() => ScaleDown(startGameButton));
            optionsButton.onMouseExit.AddListener(() => ScaleDown(optionsButton));
            exitButton.onMouseExit.AddListener(() => ScaleDown(exitButton));

            startGameButton.onClick.AddListener(startGameButton.RemoveAllListeners);

        }
        public void OnStartButtonClicked_AddListener(UnityAction listener)
        {
            startGameButton.onClick.AddListener(listener);
        }

        public void OnStartButtonClicked_RemoveListener(UnityAction listener)
        {
            startGameButton.onClick.RemoveListener(listener);
        }

        public void OnExitButtonClicked_AddListener(UnityAction listener)
        {
            exitButton.onClick.AddListener(listener);
        }

        public void OnExitButtonClicked_RemoveListener(UnityAction listener)
        {
            exitButton.onClick.RemoveListener(listener);
        }
    }
}
