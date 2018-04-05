using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CostumePickUp : MonoBehaviour {
    private GameObject scoreManager;
    public Player_Controller thePlayer;


    // Use this for initialization
    void Start () {
        scoreManager = GameObject.Find("Score Manager");
        thePlayer = GameObject.Find("Player").GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (PlayerPrefs.GetInt("Level") == 0)
            {
                PlayerPrefs.SetInt("Level", 1);
                thePlayer.CHMAX = 1;
                thePlayer.characterselect = 1; 
                SceneManager.LoadScene("One Costumes");
            }

            else if (PlayerPrefs.GetInt("Level") == 1)
            {
                PlayerPrefs.SetInt("Level", 2);
                thePlayer.CHMAX = 2;
                thePlayer.characterselect = 2;
                SceneManager.LoadScene("Two Costumes");
            }

            else if (PlayerPrefs.GetInt("Level") == 2)
            {
                PlayerPrefs.SetInt("Level", 3);
                thePlayer.CHMAX = 3;
                thePlayer.characterselect = 3;
                SceneManager.LoadScene("Three Costumes");
            }

            else if (PlayerPrefs.GetInt("Level") == 3)
            {
                PlayerPrefs.SetInt("Level", 4);
                thePlayer.CHMAX = 4;
                thePlayer.characterselect = 4;
                SceneManager.LoadScene("All Costumes");
            }
        }
    }
}
