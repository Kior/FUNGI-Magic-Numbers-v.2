using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    #region Variables

    public TMP_Text CountLabel;
    public Button ExitButton;

    public Button RestartButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
        ExitButton.onClick.AddListener(OnExitButtonClicked);

        CountLabel.text = $"Количество ходов:{MagicNumbers.GetCount}";
    }

    #endregion

    #region Private methods

    private void OnExitButtonClicked()
    {
        SceneManager.LoadScene(SceneName.Start);
    }

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneName.Game);
    }

    #endregion
}