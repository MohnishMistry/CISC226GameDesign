﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Destroyer : MonoBehaviour {

    public GameObject platformDestructionPoint; 

	// Use this for initialization
	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint"); 
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < platformDestructionPoint.transform.position.x) {
            //Destroy(gameObject); 
            gameObject.SetActive(false); 
        }
	}
}
