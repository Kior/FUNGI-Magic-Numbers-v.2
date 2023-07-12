using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class StartScreen : MonoBehaviour
    {
        #region Variables

        public Button ExitButton;

        public Button StartButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartButton.onClick.AddListener(OnStartButtonClicked);
            ExitButton.onClick.AddListener(OnExitButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnExitButtonClicked()
        {
            ApllicationQuiteService.Quit();
        }

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene(SceneName.Game);
        }

        #endregion
    }
}