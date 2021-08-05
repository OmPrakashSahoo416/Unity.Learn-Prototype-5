using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool isGameActive;
    public int livesRemaining;
    private float spawnRate = 1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    private int score;
    private int escapeKeyCounter = 0;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLives();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapeKeyCounter == 0)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
                escapeKeyCounter = 1;
            }

            else
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1f;
                escapeKeyCounter = 0;
            }          
        }
    }
    
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    private void UpdateLives()
    {
        livesText.text = "Lives : " + livesRemaining;
    }
    
    public void GameOver()
    {
        livesRemaining--;
        if (livesRemaining == 0)
        {
            livesText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
            restartButton.gameObject.SetActive(true);
        }   
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnClickRestartFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(float difficultyParameter)
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnRate /= difficultyParameter;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }
}

