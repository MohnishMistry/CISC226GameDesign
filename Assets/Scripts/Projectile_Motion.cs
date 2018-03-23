﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Motion : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(10*Time.deltaTime,0,0);

        if (gameObject.transform.position.x - player.transform.position.x > 20)
        {
            gameObject.SetActive(false);
        }
        
	}
}
