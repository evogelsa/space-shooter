using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    private float highScore;
    private float startTime;

    // Start is called before the first frame update
    void Start() {
        startTime = Time.time;
        if (PlayerPrefs.HasKey("highScore")) {
            highScore = PlayerPrefs.GetFloat("highScore");
            highScoreText.text = highScore.ToString("#0.00");
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        float score = Time.fixedTime - startTime;
        scoreText.text = score.ToString("#0.00");
        if (score > highScore) {
            highScore = score;
            highScoreText.text = highScore.ToString("#0.00");
            PlayerPrefs.SetFloat("highScore", highScore);
        }
    }
}
