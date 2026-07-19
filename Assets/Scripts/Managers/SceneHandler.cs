using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler  instance;

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        switch (CurrentState)
        {
            case GameState.MainMenu:
                Debug.Log("Entered Main Menu");
                // Reset game variables, show menu UI, etc.
                break;
            case GameState.Playing:
                Debug.Log("Game Started");
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                Debug.Log("Game Paused");
                Time.timeScale = 0f;
                break;
            case GameState.GameOver:
                Debug.Log("Game Over");
                break;
        }
    }

    public void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(currentScene);
        ChangeState(GameState.Playing);
    }

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(nextScene);
        ChangeState(GameState.Playing);
    }
}
