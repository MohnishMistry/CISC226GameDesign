using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Obstacle_Destroyer : MonoBehaviour {
    public GameObject player;
    public GameObject projectile;//wizard
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;
    public GameManager theGameManager;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
    }
	
    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("Entered Function");
        if (obj.gameObject.tag == "Projectile")
        {
            gameObject.SetActive(false);
            obj.gameObject.SetActive(false);
        }
    }


	// Update is called once per frame
	void Update () {

        if (Physics2D.IsTouching(obstacleCollider, playerCollider))
        {
            //if (controller.characterselect == 1 && controller.ability == true )
            //{
            //    gameObject.SetActive(false);
            //}
            //else
            //{
            controller.death = true;
            //}
        }
    }

}
