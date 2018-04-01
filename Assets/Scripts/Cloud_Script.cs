using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Script : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(3.0f * Time.deltaTime, 0, 0);

        if (player.transform.position.x - gameObject.transform.position.x > 15)
        {
            gameObject.SetActive(false);
        }
    }
}
