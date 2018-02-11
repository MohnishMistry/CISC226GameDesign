using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public void PlayButton(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
