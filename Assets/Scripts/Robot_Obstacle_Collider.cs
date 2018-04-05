using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Obstacle_Collider : MonoBehaviour
{
    public GameObject player;
    private Player_Controller controller;
    private Collider2D obstacleCollider;
    private Collider2D playerCollider;
    public GameManager theGameManager;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        controller = player.GetComponent<Player_Controller>();
        obstacleCollider = GetComponent<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Robot Wall")
        {
            if (controller.characterselect == 3 && controller.ability == true)
            {
                animator.SetBool("start", true);
            }
            if (Physics2D.IsTouching(obstacleCollider, playerCollider))
            {
                controller.death = true;
            }

        }

        if (gameObject.tag == "Robot Floor")
        {
             if (controller.characterselect == 3 && controller.ability == true)
             {
                animator.SetBool("start", true);
            }
        }
    }
}
