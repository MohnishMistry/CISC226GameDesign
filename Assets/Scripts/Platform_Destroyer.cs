using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Destroyer : MonoBehaviour {

    public GameObject platformDestructionPoint;

    public GameObject player;
    private Player_Controller controller;

    // Use this for initialization
    void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < platformDestructionPoint.transform.position.x) {
            //Destroy(gameObject); 
            gameObject.SetActive(false); 
        }
	}
}
