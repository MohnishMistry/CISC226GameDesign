using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject PauseUI;

    public void PlayButton(string newGame)
    {
        SceneManager.LoadScene(newGame);
        PlayerPrefs.SetInt("Level", 4); 
    }


    public void QuitButton()
    {
        Application.Quit();
    }

}
