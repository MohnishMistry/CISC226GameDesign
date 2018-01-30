using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumpStrength;
    public bool grounded;
    public bool swinging;
    public LayerMask whatIsGround;

    private Collider2D myCollider;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myAnimator.SetBool("swinging", false);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("Down arrow pressed");
            myAnimator.SetBool("swinging", true);
        }

        myAnimator.SetBool("grounded", grounded);
	}
}

