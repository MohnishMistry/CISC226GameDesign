﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumpStrength;
    public bool grounded;
    public bool ability;
    public bool death;
    public bool falling;
    public LayerMask whatIsGround;
    private bool switchCostumeLeft, switchCostumeRight;

    private Collider2D myCollider;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    public GameManager theGameManager;


    public float jumpTime;
    private float jumpTimeTracker; 

    GameObject Knight, Ghost, Robot, Wizard, KnightIcon, GhostIcon, RobotIcon, WizardIcon;
    public GameObject[] objList;
    public int characterselect;
    public int CHMAX;

    public Vector3 startingPosition; 

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            CHMAX = 1;
            Knight = GameObject.Find("Knight Costume");
            KnightIcon = GameObject.Find("Knight Icon");
            KnightIcon.SetActive(true);
            objList = new GameObject[] { Knight, KnightIcon };
        }

        if (PlayerPrefs.GetInt("Level") == 2)
        {
            CHMAX = 2;

            Knight = GameObject.Find("Knight Costume");
            KnightIcon = GameObject.Find("Knight Icon");
            KnightIcon.SetActive(true);

            Ghost = GameObject.Find("Ghost Costume");
            GhostIcon = GameObject.Find("Ghost Icon");
            GhostIcon.SetActive(false);

            objList = new GameObject[] { Knight, Ghost, KnightIcon, GhostIcon };

        }

        if (PlayerPrefs.GetInt("Level") == 3)
        {
            CHMAX = 3;

            Knight = GameObject.Find("Knight Costume");
            KnightIcon = GameObject.Find("Knight Icon");
            KnightIcon.SetActive(true);

            Ghost = GameObject.Find("Ghost Costume");
            GhostIcon = GameObject.Find("Ghost Icon");
            GhostIcon.SetActive(false);

            Robot = GameObject.Find("Robot Costume");
            RobotIcon = GameObject.Find("Robot Icon");
            RobotIcon.SetActive(false);

            objList = new GameObject[] { Knight, Ghost, Robot, KnightIcon, GhostIcon, RobotIcon};

        }

        if (PlayerPrefs.GetInt("Level") == 4)
        {
            CHMAX = 4;

            Knight = GameObject.Find("Knight Costume");
            KnightIcon = GameObject.Find("Knight Icon");
            KnightIcon.SetActive(true);

            Ghost = GameObject.Find("Ghost Costume");
            GhostIcon = GameObject.Find("Ghost Icon");
            GhostIcon.SetActive(false);

            Robot = GameObject.Find("Robot Costume");
            RobotIcon = GameObject.Find("Robot Icon");
            RobotIcon.SetActive(false);

            Wizard = GameObject.Find("Wizard Costume");
            WizardIcon = GameObject.Find("Wizard Icon");
            WizardIcon.SetActive(false);

            objList = new GameObject[] { Knight, Ghost, Robot, Wizard, KnightIcon, GhostIcon, RobotIcon, WizardIcon };
        }

        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        myAnimator = Knight.GetComponent<Animator>();
        myAnimator.SetBool("ability", false);
        characterselect = 1;
        jumpTimeTracker = jumpTime;
        switchCostumeLeft = false;
        switchCostumeRight = false;
        falling = false;
        death = false;
        startingPosition = transform.position; 
    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myAnimator.SetBool("grounded", grounded);
        ability = myAnimator.GetBool("ability");

        //if (death == true)
        //{
        //    theGameManager.RestartGame();
        //}


        for (int i = 0; i < CHMAX * 2; i++)
        {
            if (i != characterselect - 1 && i != characterselect + CHMAX - 1)
            {
                objList[i].SetActive(false);
            }
            else
            {
                objList[i].SetActive(true);
            }
        }
        myAnimator = objList[characterselect-1].GetComponent<Animator>();
        

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && grounded && !falling )
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
        }


        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button0)) && !falling)
        {
            if (jumpTimeTracker > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
                jumpTimeTracker -= Time.deltaTime; 
            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            jumpTimeTracker = 0; 
        }

        if (grounded)
        {
            jumpTimeTracker = jumpTime; 
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyUp(KeyCode.Joystick1Button2)))
        {
            myAnimator.SetBool("ability", true);
            
        }

        myAnimator.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.RightArrow) || switchCostumeRight== true || Input.GetKeyUp(KeyCode.Joystick1Button5))
        {   
            if (ability == true)
            {
                switchCostumeRight = true;
            }

            else if ( characterselect == CHMAX)
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
                characterselect = CHMAX;
                switchCostumeLeft = false;
            }
            else
            {
                characterselect = characterselect - 1;
                switchCostumeLeft = false;
            }
        }

	}


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "nojumpbox")
        {
            falling = true; //Just need to make bool work with jump press
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "killbox")
        {
            death = true;
            falling = false;
        }

    }
}

