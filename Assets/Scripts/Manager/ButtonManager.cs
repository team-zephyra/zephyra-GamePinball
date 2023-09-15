using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Transform bola;
    [SerializeField] private GameObject gameOverGO;
    [SerializeField] private Transform spawnPosition;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartButton()
    {
        // Disable GameOverUI Game Object
        gameOverGO.SetActive(false);

        // Respawn Bola
        bola.position = spawnPosition.position;

        // Reset Score
        scoreManager.ResetScore();
    }

    public void ReturnToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
