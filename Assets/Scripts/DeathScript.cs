using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    public GameObject DeathUI;
    public Player_Controller Controller;
    private AudioSource DeathBell;
    private AudioClip DeathBellSound;
    private bool PlayedDeath;

    public GameManager theGameManager; 
    void Start()
    {
        PlayedDeath = false;
        DeathUI.SetActive(false);
        player = GameObject.Find("Player");
        DeathBell = GameObject.Find("Death Bell").GetComponent<AudioSource>();
        Controller = player.GetComponent<Player_Controller>();
    }

    void Update()
    {
        if (Controller.death == true)
        {   
            if (PlayedDeath == false)
            {
                DeathBell.Play();
                PlayedDeath = true;
            }
            Died();
        }
    }

    public void Died()
    {
        GameObject.Find("Background Music").GetComponent<AudioSource>().Stop();
        DeathUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart(string newGame)
    {
        DeathUI.SetActive(false);
        Time.timeScale = 1;
        PlayedDeath = false;
        theGameManager.RestartGame();

    }

    public void Quit()
    {
        Application.Quit();
    }
}
