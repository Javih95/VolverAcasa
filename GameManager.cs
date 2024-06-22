using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxLives = 3;
    public GameObject gameOverUI;
    public GameObject victoryUI;

    public int lives;
    public int points;
    public bool gameIsOver;
    private bool gameInitialized;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            lives = maxLives;
            points = 0;
            gameIsOver = false;
            gameInitialized = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (!gameInitialized)
        {
            InitializeGame();
            gameInitialized = true;
        }
    }
    void Update()
    {
        if (!gameIsOver)
        { gameOverUI.SetActive(false); }
    }
    public void AddPoints(int amount)
    {
        points += amount;
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void Victory()
    {
        gameIsOver = true;
        victoryUI.SetActive(true);
    }

    public void GameOver()
    {
        gameIsOver = true;
   
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        InitializeGame();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        //InitializeGame();
    }
    public void LoadScene(string escena)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escena);
        //InitializeGame();
    }

    public void InitializeGame()
    {
        lives = maxLives;
        points = 0;
        gameIsOver = false;

    }

}
