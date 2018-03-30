using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Obstacle_Destroyer_Dummy : MonoBehaviour
{
    public GameObject player;
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;
    public GameManager theGameManager;
    private AudioSource DestructionSound;
 


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        DestructionSound = GameObject.Find("Dummy Audio").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Physics2D.IsTouching(obstacleCollider, playerCollider))
        {
            if (controller.characterselect == 1 && controller.ability == true )
            {
                DestructionSound.Play();
                gameObject.SetActive(false);
            }
            else
            {
                controller.death = true;
            }
        }
    }
}
