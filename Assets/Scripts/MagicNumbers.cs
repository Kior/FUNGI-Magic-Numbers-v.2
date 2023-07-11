using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public TMP_Text Count;
    public TMP_Text Text;
    
    public int DefaultMax = 1000;
    public int DefaultMin = 1;
    public Button DownButton;
    public Button GuessButton;
    public Button UpButton;

    private int _guess;
    private bool _isNewGame;
    private int _max;
    private int _min;
    private int _press;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        DownButton.onClick.AddListener(OnDownButtonClicked);
        UpButton.onClick.AddListener(OnUpButtonClicked);
        GuessButton.onClick.AddListener(OnGuessButtonClicked);
        Restart();
    }

    private void OnGuessButtonClicked()
    {
        SetText($"Поздравляю! Я угадал! Твоё число {_guess}. Сделано {_press} ходов! Нажми пробел чтобы завершить новую игру. Значения min, max и guess будут сброшены. Либо нажми ESC чтобы завершить игру.");
        _isNewGame = true;
    }

    private void OnUpButtonClicked()
    {
        _min = _guess;
        _press++;
        CalculateGuess();
        AskAboutGuess();
        TurnCount();
    }

    private void OnDownButtonClicked()
    {
        _max = _guess;
        _press++;
        CalculateGuess();
        AskAboutGuess();
        TurnCount();
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
                SceneManager.LoadScene("WinScene");
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = _guess;
            _press++;
            CalculateGuess();
            AskAboutGuess();
            TurnCount();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = _guess;
            _press++;
            CalculateGuess();
            AskAboutGuess();
            TurnCount();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetText($"Поздравляю! Я угадал! Твоё число {_guess}. Сделано {_press} ходов! Нажми пробел чтобы завершить новую игру. Значения min, max и guess будут сброшены. Либо нажми ESC чтобы завершить игру.");
            _isNewGame = true;
        }
    }

    #endregion

    #region Private methods

    private void AskAboutGuess()
    {
        SetText($"Твоё число {_guess}?");
    }

    private void CalculateGuess()
    {
        _guess = (_min + _max) / 2;
    }

    private void Restart()
    {
        _max = DefaultMax;
        _min = DefaultMin;
        _press = 0;
        SetText($"Привет! Загадай число от {_min} до {_max}");
        CalculateGuess();
        AskAboutGuess();
        _isNewGame = false;
        //ctrl + R + M, быстро создать метод на повторяющиеся строки.
    }

    private void SetCount(string count)
    {
        Count.text = count;
    }

    private void SetText(string text)
    {
        Text.text = text;
    }

    private void TurnCount()
    {
        SetCount($"Количество ходов {_press}.");
    }

    #endregion
}