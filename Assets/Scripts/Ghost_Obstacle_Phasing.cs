using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Obstacle_Phasing : MonoBehaviour {

    public GameObject player;
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (controller.ability == true && controller.characterselect == 2)
        {
            obstacleCollider.enabled=false;
        }
        else if (controller.ability == false)
        {
            obstacleCollider.enabled = true;
        }
    }
}
