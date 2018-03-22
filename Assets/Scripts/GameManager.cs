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

    private ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
        backgroundStartPoint = BackgroundGenerator.position;
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>(); 
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
        scoreManager.increasingScore = false; 
        thePlayer.death = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        BackgroundGenerator.position = backgroundStartPoint;
        thePlayer.gameObject.SetActive(true);
        OnDeathClear();

        scoreManager.scoreCounter = 0;
        scoreManager.increasingScore = true;
    }

    List<GameObject> FindGameObjectsWithLayer(int layer)
    {
        GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> goList = new List<GameObject>();

        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList;
    }

    void OnDeathClear()
    {
        GameObject Start;
        Start = GameObject.Find("Start");

        List<GameObject> backgrounds = FindGameObjectsWithLayer(11);
        if (backgrounds != null)
        {
            foreach (GameObject background in backgrounds)
            {
                if (background.name != "Start Background")
                {
                    background.SetActive(false);
                }
            }
        } 
 
        List<GameObject> obstacles = FindGameObjectsWithLayer(10);
        if (obstacles != null)
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.SetActive(false);
            }
        } 

        List<GameObject> grounds = FindGameObjectsWithLayer(8);
        if (grounds != null)
        {
            foreach (GameObject ground in grounds)
            {
                ground.SetActive(false);
            }
            Start.SetActiveRecursively(true);
        } 
    }
}
