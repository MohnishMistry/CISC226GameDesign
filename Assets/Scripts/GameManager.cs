using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public Transform BackgroundGenerator;
    private Vector3 backgroundStartPoint;

    public Player_Controller thePlayer;
    private Vector3 playerStartPoint;

	// Use this for initialization
	void Start () {
        backgroundStartPoint = BackgroundGenerator.position;
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        thePlayer.death = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        BackgroundGenerator.position = backgroundStartPoint;
        thePlayer.gameObject.SetActive(true);
    }
}
