using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class StartScreen : MonoBehaviour
    {
        #region Variables

        public Button StartButton;
        public Button ExitButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartButton.onClick.AddListener(OnStartButtonClicked);
            ExitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Зачем вышел? Играй давай.");
        }

        #endregion

        #region Private methods

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene("GameScene");
        }

        #endregion
    }
}