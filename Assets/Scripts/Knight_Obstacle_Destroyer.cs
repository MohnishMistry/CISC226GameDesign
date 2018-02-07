using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Obstacle_Destroyer : MonoBehaviour {
    public GameObject player;
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Physics2D.IsTouching(obstacleCollider, playerCollider) && controller.characterselect==1)
        {
            if (controller.ability == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
