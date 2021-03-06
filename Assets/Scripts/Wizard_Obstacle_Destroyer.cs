﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Obstacle_Destroyer : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;//wizard
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;
    public GameManager theGameManager;
    private AudioSource DestructionSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        DestructionSound = GameObject.Find("Troll and Wolf Destruction").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Projectile")
        {
            DestructionSound.Play();
            //obj.gameObject.GetComponent<Projectile_Motion>().ready_Projectile = true;
            //obj.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Physics2D.IsTouching(obstacleCollider, playerCollider))
        {
            controller.death = true;          
        }
    }

}