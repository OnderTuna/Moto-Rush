using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    private int score;
    private float startDelay = 2.5f;
    private float repeatRate = 5f;
    public bool isGameActive;

    [Header("Texts")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    [Header("Buttons")]
    public Button restartButton;

    [Header("Objects")]
    public GameObject[] spawnPrefab;
    public GameObject gamePanel;

    void SpawnPrefabs()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-4, 4), 0.1f, 100);
        int index = Random.Range(0, spawnPrefab.Length);

        if (isGameActive == true)
        {
            Instantiate(spawnPrefab[index], spawnPos, spawnPrefab[index].transform.rotation);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        InvokeRepeating(nameof(SpawnPrefabs), startDelay, repeatRate);
        gamePanel.gameObject.SetActive(false);
    }
}
