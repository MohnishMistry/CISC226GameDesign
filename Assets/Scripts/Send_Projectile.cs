﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send_Projectile : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    private Player_Controller controller;


    public Object_Pooler[] projectilePool;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        projectile = projectilePool[0].GetPooledObject(); ;
        controller = player.GetComponent<Player_Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.characterselect == 1 && controller.ability == true && projectile.activeSelf == false)
        {
            Spawn_Projectile(player.transform.position);
        }
    }

    void Spawn_Projectile (Vector3 position)
    {
        Vector3 newPosition = new Vector3 (position.x, position.y-0.5f, position.z);
        projectile.transform.position = newPosition;
        projectile.SetActive(true);
    }
}
