using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    public GameObject DeathUI;
    public Player_Controller Controller;

    public GameManager theGameManager; 
    void Start()
    {
        DeathUI.SetActive(false);
        player = GameObject.Find("Player");
        Controller = player.GetComponent<Player_Controller>();
    }

    void Update()
    {
        if (Controller.death == true)
        {
            Died();
        }
    }

    public void Died()
    {
        DeathUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart(string newGame)
    {
        DeathUI.SetActive(false);
        Time.timeScale = 1;
        //SceneManager.LoadScene(newGame);
        theGameManager.RestartGame(); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
