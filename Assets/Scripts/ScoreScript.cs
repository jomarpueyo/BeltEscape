using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text scoreText;
    string finalScore;
    GameManager gameManager;
    int multiplier;
    public bool gameHasEnded = false;
    public bool newHighScore = false;

    void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        if (!gameHasEnded) updateScore();
        else               endScore();
	}

    void updateScore()
    {
        scoreText.text = gameManager.gameTime.ToString("0.0");
    }

    void endScore()
    {
        finalScore = gameManager.finalScore.ToString("0.0");
        scoreText.alignment = TextAnchor.MiddleCenter;
        scoreText.fontSize = 50;

        if (newHighScore)
        {
            scoreText.text = "New High Score!\n" + finalScore;
        } else
        {
            scoreText.text = "Final Score\n" + finalScore;
        }
    }
}
