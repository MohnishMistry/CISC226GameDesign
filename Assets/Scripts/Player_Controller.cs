using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumpStrength;
    public bool grounded;
    public bool ability;
    public bool death;
    public LayerMask whatIsGround;
    private bool switchCostumeLeft, switchCostumeRight;

    private Collider2D myCollider;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    public GameManager theGameManager;


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
        myAnimator.SetBool("ability", false);
        jumpTimeTracker = jumpTime;
        switchCostumeLeft = false;
        switchCostumeRight = false;
        death = false;

    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myAnimator.SetBool("grounded", grounded);
        ability = myAnimator.GetBool("ability");

        if (death == true)
        {
            theGameManager.RestartGame();
        }

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


        //<<<<<<< HEAD
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            if (jumpTimeTracker > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
                jumpTimeTracker -= Time.deltaTime; 
            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            jumpTimeTracker = 0; 
        }

        if (grounded)
        {
            jumpTimeTracker = jumpTime; 
        }
//=======

        if ((Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyUp(KeyCode.Joystick1Button0)))
        {
            myAnimator.SetBool("ability", true);
            
        }



//>>>>>>> Ghost-Texture
        myAnimator.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.RightArrow) || switchCostumeRight== true || Input.GetKeyUp(KeyCode.Joystick1Button5))
        {   
            if (ability == true)
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

        if (Input.GetKeyDown(KeyCode.LeftArrow) || switchCostumeLeft== true || Input.GetKeyUp(KeyCode.Joystick1Button4))
        {
            if (ability == true)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
        }
    }
}

