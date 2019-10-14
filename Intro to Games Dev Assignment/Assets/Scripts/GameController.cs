using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject enemyShip;

    private int score;
    private int highScore;
    private int asteroidsRemaining;
    private int enemiesRemaining = 1;
    private int lives;
    private int wave;
    private int increaseEachWave = 4;

    private Vector3 bigAsteroidScale = new Vector3(1.5f, 1.5f, 1.5f);

    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void BeginGame()
    {
        score = 0;
        lives = 3;
        wave = 1;

        //HUD
        scoreText.text = "SCORE: " + score;
        highScoreText.text = "HIGH SCORE: " + highScore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;

        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        DestroyExistingAsteroids();

        // No. of asteroids to spawn
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++) // Spawning asteroids
        {
            // Generate random points on screen
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            Vector2 spawnPos = new Vector2(spawnX, spawnY);

            GameObject bigAsteroid = Instantiate(asteroid, spawnPos, Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f))) as GameObject;
            bigAsteroid.transform.localScale = bigAsteroidScale;
        } // new Vector3(Random.Range(-9.0f, 9.0f)

        if (wave % 2 == 0)
        {
            for (int i = 0; i < enemiesRemaining; i++)
            {
                // Generate random points on screen
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);

                GameObject enemy = Instantiate(enemyShip, spawnPos, Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f))) as GameObject;
            }
            enemiesRemaining = enemiesRemaining + 1;
        }
        
        waveText.text = "WAVE: " + wave;
    }

    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            GameObject.Destroy(asteroid);
        }
    }

    public void IncrementScore()
    {
        score++;

        scoreText.text = "SCORE: " + score;

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "HIGH SCORE: " + highScore;

            // Saving high score
            PlayerPrefs.SetInt("highScore", highScore);
        }

        // If player has destroyed all asteroids, being new wave
        if (asteroidsRemaining < 1)
        {
            wave++;
            SpawnAsteroids();
        }
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        //If player has run out of lives, restart game
        if (lives < 1)
        {
            BeginGame();
        }
    }

    public void DecrementAsteroids()
    {
        asteroidsRemaining--;
    }

    public void SplitAsteroid()
    {
        asteroidsRemaining += 2; // asteroids - 1 + 3 as a big asteroid will split into 3
    }
}
