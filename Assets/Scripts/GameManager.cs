using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public float slowness = 10f;
    public float gameTime;
    public float finalScore;
    public bool gameEnded;
    public bool isPc;
    public bool isMobile;
    public bool isMobileAccelerator;

    void Awake()
    {
        gameEnded   = false;
        isPc        = true;
        isMobile    = false;
        isMobileAccelerator = false;
    }

    void Update()
    {
        gameTime = Time.timeSinceLevelLoad;
        if (gameEnded)
        {
            if (isPc)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    fixTimeScale();
                    SceneLoader.FindObjectOfType<SceneLoader>().LoadScene("MainMenu");
                }
                if (Input.anyKeyDown && !Input.GetKey(KeyCode.Escape))
                {
                    fixTimeScale();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

            if (isMobile)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && touch.position.x < Screen.width / 2) //Left
                {
                    fixTimeScale();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2) //Right
                {
                    fixTimeScale();
                    SceneLoader.FindObjectOfType<SceneLoader>().LoadScene("MainMenu");
                }
            }
        }
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            finalScore = gameTime;

            if (finalScore > PlayerPrefs.GetFloat("Highscore", 0))
            {
                PlayerPrefs.SetFloat("Highscore", finalScore);
                FindObjectOfType<ScoreScript>().newHighScore = true;
            }
            FindObjectOfType<ScoreScript>().gameHasEnded = true;

            Time.timeScale = 1f / slowness;
            Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        }
    }

    public void fixTimeScale()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
    }
}
