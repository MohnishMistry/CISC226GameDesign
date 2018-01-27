using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumpStrength;
    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    public float jumpTime;
    private float jumpTimeTracker; 


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        jumpTimeTracker = jumpTime; 
    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeTracker > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
                jumpTimeTracker -= Time.deltaTime; 
            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpTimeTracker = 0; 
        }

        if (grounded)
        {
            jumpTimeTracker = jumpTime; 
        }
        myAnimator.SetBool("grounded", grounded);
	}
}

