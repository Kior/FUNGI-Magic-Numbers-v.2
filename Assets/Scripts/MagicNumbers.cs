using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public TMP_Text Count;

    public int DefaultMax = 1000;
    public int DefaultMin = 1;
    public Button DownButton;
    public Button ExitButton;
    public Button GuessButton;
    public TMP_Text Label;
    public Button RestartButton;
    public Button UpButton;

    private int _guess;
    private bool _isNewGame;
    private int _max;
    private int _min;

    #endregion

    #region Properties

    public static int GetCount { get; private set; }

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        ExitButton.onClick.AddListener(OnExitButtonClicked);
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
        DownButton.onClick.AddListener(OnDownButtonClicked);
        UpButton.onClick.AddListener(OnUpButtonClicked);
        GuessButton.onClick.AddListener(OnGuessButtonClicked);
        ExitButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        Restart();
    }

    private void Update()
    {
        if (_isNewGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }

            if (_isNewGame && Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneName.Win);
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnDownButtonClicked();

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnUpButtonClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnGuessButtonClicked();
        }
    }

    #endregion

    #region Private methods

    private void AskAboutGuess()
    {
        SetLabelText($"Твоё число {_guess}?");
    }

    private void CalculateGuess()
    {
        _guess = (_min + _max) / 2;
    }

    private void OnDownButtonClicked()
    {
        _max = _guess;
        GetCount++;
        CalculateGuess();
        AskAboutGuess();
        SetCountText();
    }

    private void OnExitButtonClicked()
    {
        if (_isNewGame)
        {
            SceneManager.LoadScene(SceneName.Win);
        }
    }

    private void OnGuessButtonClicked()
    {
        SetLabelText(
            $"Поздравляю! Я угадал! Твоё число {_guess}. Сделано {GetCount} ходов! Нажми пробел чтобы перезапустить игру или ESC чтобы завершить игру.");
        _isNewGame = true;
        ExitButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    private void OnRestartButtonClicked()
    {
        _max = DefaultMax;
        _min = DefaultMin;
        GetCount = 0;
        SetLabelText($"Привет! Загадай число от {_min} до {_max}");
        SetCountText($"Количество ходов {GetCount}");
        CalculateGuess();
        AskAboutGuess();
        _isNewGame = false;
        ExitButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
    }

    private void OnUpButtonClicked()
    {
        _min = _guess;
        GetCount++;
        CalculateGuess();
        AskAboutGuess();
        SetCountText();
    }

    private void Restart()
    {
        OnRestartButtonClicked();
    }

    private void SetCountText(string count)
    {
        Count.text = count;
    }

    private void SetCountText()
    {
        SetCountText($"Количество ходов {GetCount}");
    }

    private void SetLabelText(string text)
    {
        Label.text = text;
    }

    #endregion
}