using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CostumePickUp : MonoBehaviour {
    private GameObject scoreManager;


    // Use this for initialization
    void Start () {
        scoreManager = GameObject.Find("Score Manager"); 
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DontDestroyOnLoad(scoreManager);
        SceneManager.LoadScene("Three Costumes");

    }


}
