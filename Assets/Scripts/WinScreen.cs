using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    #region Variables

    public Button RestartButton;
    public Button ExitButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
        ExitButton.onClick.AddListener(OnExitButtonClicked);
    }

    #endregion

    #region Private methods

    private void OnExitButtonClicked()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}