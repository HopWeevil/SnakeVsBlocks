using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Snake _snake;
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private SnakeHeadTracker _tracker;
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private LevelCompleteScreen _levelCompleteScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private StartGameScreen _startGameScreen;
    [SerializeField] private LevelTransitionScreen _levelTransitionScreen;
   
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _levelLenth;

    private void OnEnable()
    {
        _snakeHead.FinishReached += OnFinishReached;
        _levelTransitionScreen.LevelTransitionComplete += OnLevelTransitionCompleted;
        _levelCompleteScreen.Closed += OnLevelCompleteScreenClosed;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _startGameScreen.StartButtonClick += OnStartButonClick;
        _snake.Died += OnSnakeDied;
    }

    private void OnDisable()
    {
        _snakeHead.FinishReached -= OnFinishReached;
        _levelTransitionScreen.LevelTransitionComplete -= OnLevelTransitionCompleted;
        _levelCompleteScreen.Closed -= OnLevelCompleteScreenClosed;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _startGameScreen.StartButtonClick -= OnStartButonClick;
        _snake.Died -= OnSnakeDied;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        int snakeSize = SaveSystem.LoadSnakeSize(_snake);
        _currentLevel = SaveSystem.LoadLevelNubmer();
        _startGameScreen.Show();
        _snake.Initializate(snakeSize);
        _levelGenerator.Generate(_levelLenth);
        _levelProgress.SetLevelNumbers(_currentLevel);
    }

    private void OnSnakeDied()
    {
        SaveSystem.SaveSnakeSize(_snake.DefaultTailSize);
        _gameOverScreen.Show();
        _tracker.enabled = false;
        _levelProgress.enabled = false;
    }

    private void OnStartButonClick()
    {
        _startGameScreen.Hide();
        _levelProgress.Show();
        _snake.enabled = true;
        _tracker.enabled = true;
    }

    private void OnFinishReached()
    {
        SaveSystem.SaveSnakeSize(_snake.CurrentSize);
        SaveSystem.SaveLevelNubmer(_currentLevel + 1);
        _levelProgress.PlayMarkerAnimation();
        _tracker.enabled = false;
        _levelCompleteScreen.Show();
    }

    private void OnRestartButtonClick()
    {
        _levelTransitionScreen.StartTransition();
    }

    private void OnLevelCompleteScreenClosed()
    {
        _levelTransitionScreen.StartTransition();
    }

    private void OnLevelTransitionCompleted()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}