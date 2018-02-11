using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score_Manager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCounter;
    public float highScoreCounter;

    public float pointsPerSecond;

    public bool increasingScore; 

	// Use this for initialization
	void Start () {
        increasingScore = true;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCounter = PlayerPrefs.GetFloat("HighScore"); 
        }
	}
	
	// Update is called once per frame
	void Update () {

        scoreCounter += pointsPerSecond * Time.deltaTime;

        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("HighScore", highScoreCounter); 
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCounter);
        highScoreText.text = "HighScore: " + Mathf.Round(highScoreCounter);
              

    }
}
