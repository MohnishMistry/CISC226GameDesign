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
        myAnimator.SetBool("swinging", false);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Physics2D.IgnoreLayerCollision(9, 10, false);
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
        }

//<<<<<<< HEAD
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
//=======
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("Down arrow pressed");
            Physics2D.IgnoreLayerCollision(9, 10, true);
            myAnimator.SetBool("swinging", true);
        }

//>>>>>>> Ghost-Texture
        myAnimator.SetBool("grounded", grounded);
	}
}

