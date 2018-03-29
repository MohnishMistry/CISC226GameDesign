using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject PauseUI;
    public GameObject player;
    public Player_Controller Controller;
    public GameManager theGameManager;

    void Start()
    {
        PauseUI.SetActive(false);
        player = GameObject.Find("Player");
        Controller = player.GetComponent<Player_Controller>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Controller.death == false)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }

    public void Restart(string newGame)
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
        theGameManager.RestartGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
