using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject PauseUI;

    public void PlayButton(string newGame)
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene(newGame);
    }


    public void QuitButton()
    {
        Application.Quit();
    }

}
