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

    GameObject Knight, Ghost;
    int characterselect = 1;


	// Use this for initialization
	void Start () {
        Knight = GameObject.Find("Knight Costume");
        Ghost = GameObject.Find("Ghost Costume");
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = Knight.GetComponent<Animator>();     
    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myAnimator.SetBool("swinging", false);
        myAnimator.SetBool("grounded", grounded);

        if (characterselect == 1)
        {
            Knight.SetActive(true);
            myAnimator = Knight.GetComponent<Animator>();
            Ghost.SetActive(false);
        }

        else if (characterselect == 2)
        {
            Ghost.SetActive(true);
            myAnimator = Ghost.GetComponent<Animator>();
            Knight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && characterselect == 1)
        {
            myAnimator.SetBool("swinging", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ( characterselect == 2)
            {
                characterselect = 1;

            }
            else
            {
             characterselect = characterselect + 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (characterselect == 1)
            {
                characterselect = 2;
            }
            else
            {
                characterselect = characterselect - 1;
            }
        }
	}
}

