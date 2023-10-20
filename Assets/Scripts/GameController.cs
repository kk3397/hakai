using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject hazards;

    public Vector2 minBound, maxBound;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOver;
    private int score;

    private GameController gameController;
    private int playerLives;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        playerLives = 3;
        UpdateLives();
        isDead = false;
        gameOver.SetActive(false);


        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController script");
        }

        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves() { 
    yield return new WaitForSeconds(startWait);// waits for the game to start
        while (true) {
            for (int i = 0; i<hazardCount; i++) {
               
    Quaternion spawnRotation = Quaternion.identity;
     var enemy=Instantiate(hazards, randomSpawn(minBound, maxBound), spawnRotation);
    yield return new WaitForSeconds(spawnWait);// waits for hazards to appear
}
yield return new WaitForSeconds(waveWait);
 }
}
    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 randomSpawn(Vector2 min, Vector2 max)
    {
        Vector2 newPos = new Vector2();
        newPos.x=Random.Range(min.x,max.x);
        newPos.y=Random.Range(min.y,max.y);
        return newPos;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives()
    {
        livesText.text = "Lives: " + playerLives;
    }
    public void LiveCount()
    {
        playerLives--;
        UpdateLives();
        if (playerLives <= 0)
        {
            isDead = true;
        }

    
    }
    public void endGame()
    {
        gameOver.SetActive(true);
        hazardCount = 0;
        
    }
}
