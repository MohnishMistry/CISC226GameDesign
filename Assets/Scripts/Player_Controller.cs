using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumpStrength;
    public bool grounded;
    public bool swinging;
    public LayerMask whatIsGround;
    private bool switchCostumeLeft, switchCostumeRight;

    private Collider2D myCollider;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;


    public float jumpTime;
    private float jumpTimeTracker; 

    GameObject Knight, Ghost;
    public int characterselect = 1;



	// Use this for initialization
	void Start () {
        Knight = GameObject.Find("Knight Costume");
        Ghost = GameObject.Find("Ghost Costume");
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        myAnimator = Knight.GetComponent<Animator>();
        myAnimator.SetBool("swinging", false);
        jumpTimeTracker = jumpTime;
        switchCostumeLeft = false;
        switchCostumeRight = false;

    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myAnimator.SetBool("grounded", grounded);

        if (characterselect == 1)
        {
            Knight.SetActive(true);
            myAnimator = Knight.GetComponent<Animator>();
            myAnimator.SetInteger("costume", characterselect);
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

        if (Input.GetKeyDown(KeyCode.DownArrow) && characterselect == 1)

        {
            myAnimator.SetBool("swinging", true);
        }


//>>>>>>> Ghost-Texture
        myAnimator.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.RightArrow) || switchCostumeRight==true)
        {   
            if (swinging == true)
            {
                switchCostumeRight = true;
            }

            else if ( characterselect == 2)
            {
                characterselect = 1;
                switchCostumeRight = false;

            }
            else
            {
             characterselect = characterselect + 1;
             switchCostumeRight = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || switchCostumeLeft== true)
        {
            if (swinging == true)
            {
                switchCostumeLeft = true;
            }

            else if (characterselect == 1)
            {
                characterselect = 2;
                switchCostumeLeft = false;
            }
            else
            {
                characterselect = characterselect - 1;
                switchCostumeLeft = false;
            }
        }

	}
}

