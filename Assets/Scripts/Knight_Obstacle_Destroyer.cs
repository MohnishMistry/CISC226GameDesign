using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Obstacle_Destroyer : MonoBehaviour {
    public GameObject player;
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;
    public GameManager theGameManager;

    public AudioSource swordSwingingSound; 
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        swordSwingingSound = GameObject.Find("SwordSwingingSound").GetComponent<AudioSource>(); 

    }
	
	// Update is called once per frame
	void Update () {

        if (Physics2D.IsTouching(obstacleCollider, playerCollider))
        {
            if (controller.characterselect == 1 && controller.ability == true )
            {
                swordSwingingSound.Play(); 
                gameObject.SetActive(false);
            }
            else
            {
                controller.death = true;
            }
        }
    }
}
