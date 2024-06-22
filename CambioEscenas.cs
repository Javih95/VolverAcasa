using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambioEscenas : MonoBehaviour
{
    public void LoadScene(string escena)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escena);
    }
    public void RestartGame()
    {
        GameManager.Instance.gameIsOver = false;
    }
    public void iniciarJuego()
    {
        GameManager.Instance.InitializeGame();
    }
}
