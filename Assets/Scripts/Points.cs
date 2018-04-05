using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public ScoreManager scoreManager;
    public int pointsToGive;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.gameObject.name == "Player")
        {
            scoreManager.AddPoints(pointsToGive);
            GameObject.Find("Candy Crunch").GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);

        }
    }
}
