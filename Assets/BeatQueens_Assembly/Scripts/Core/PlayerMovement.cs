using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public float PlayerSpeed = 4;
    public float PlayerNoSpeed = 0;
    public float PlayerDashStopSpeed = 0.1f;
    public float PlayerFallSpeed = 4;
    public float DashSpeed = 20;
    public float PlayerJumpSpeed = 12;
    public bool OnFloor;
    public Rigidbody PlayerRB;
    public bool FacingLeft;
    public bool FacingRight;
    public bool pressedDash;
    public bool dashLeft;
    public bool dashRight;
    public bool dashStop;
    public bool walkingRight;
    public bool walkingLeft;
    public bool noDanceKeysPressed;
    public bool playerAirDown;
    public float maxDashTime = 5; //Controls length of dash so you cant dash continuously.
    public float currentDashTime = 0;
    private float playerGravity = 14.0f;
    private float verticalVelocity;
    public Vector3 moveDirection;
    //private int direction;
    public bool playerIsMoving;


    Material blue;


    CharacterController CharC;


    // Dance code
    public bool playerLocked;
    public GameObject Navi;


    //animation code
    //public Animator playerAnimator;
    public Animator Navi3DAnimator;


    // Use this for initialization
    void Start()
    {
        CharC = GetComponent<CharacterController>();
        PlayerRB = GetComponent<Rigidbody>();
        FacingLeft = true;
        FacingRight = false;
        currentDashTime = maxDashTime;
        OnFloor = true;
        pressedDash = false;


        //Combat/Dance mode related code
        playerLocked = true; //Boolean that sets players constaints based on combat mode
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |  RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ; //Players constraints are unfrozen


    }


    ///////////////COLLISION CODE START ///////////////////

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage" && OnFloor)
        {
            OnFloor = true;



        }
        if (collision.gameObject.tag == "Ground")
        {
            OnFloor = true;
            PlayerJumpSpeed = 12;
            verticalVelocity = -playerGravity * Time.deltaTime;


        }

        if (collision.gameObject.tag == "Damage")
        {
            //Destroy(other.gameObject); //Destroys other game object
            Destroy(collision.gameObject); //Destroys game onject you collided with
        }



        if(PlayerRB.velocity.magnitude < 0.1f)
        {
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            playerIsMoving = false;
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Debug.Log("Calling magnitude code line 101 playermovementscript");
        }

        /*

        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject); //Destroys other game object
           // Destroy(collision.gameObject); //Destroys game onject you collided with
            Debug.Log("Player has been hit by enemy hand!");
        } */

    }

    void OnCollisionExit(Collision collision) //Sets onFloor to off when you jump. Movement is resricted
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnFloor = false;

        }

    }


    ///////////////COLLISION CODE END ///////////////////

    // Update is called once per frame
    void Update()
    {


        ////Stop the player from rotating Code////
        ///
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |  RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ; //Prevents the player from spinning wildly if they collide with an object.
        //////////DASHING CODE START ///////////////////
        ///


        if (OnFloor == true)
        {
            Navi3DAnimator.SetBool("NaviOnGround", true);
            Navi3DAnimator.SetBool("NaviFallLeft", false);
            Navi3DAnimator.SetBool("NaviFallRight", false);
            Navi3DAnimator.SetBool("NaviFallUpLeft", false);
            Navi3DAnimator.SetBool("NaviFallUpRight", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
        }

        if (OnFloor == false)
        {
            Navi3DAnimator.SetBool("NaviOnGround", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);
        }


        if (Input.GetKeyDown(KeyCode.RightShift) == true && playerLocked == false)
        {
            pressedDash = true;
            currentDashTime = 0;
            print("Character dashing");


        }



        if (Input.GetKeyDown(KeyCode.RightShift) == true && FacingLeft == true && playerLocked == false)
        {
            FacingLeft = true;
            FacingRight = false;
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", true);
            Navi3DAnimator.SetBool("NaviDashRight", false);

            Navi3DAnimator.SetBool("NaviSpeed0", false);


        }



        if (Input.GetKeyDown(KeyCode.RightShift) == true && FacingRight == true && playerLocked == false)
        {

            //FacingLeft = false;
            FacingRight = true;
            FacingLeft = false;
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", true);

            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.RightShift) == true && FacingLeft == true && playerLocked == false && Input.GetKeyDown(KeyCode.A) == true)
        {

            //FacingRight = false;
            FacingLeft = true;
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", true);
            Navi3DAnimator.SetBool("NaviDashRight", false);

            Navi3DAnimator.SetBool("NaviSpeed0", false);

        


        }

        //Controls character switching in mid air from dash left to dash right

        if (Input.GetKeyDown(KeyCode.RightShift) == true && FacingRight == true && playerLocked == false && Input.GetKeyDown(KeyCode.A) == true)
        {

            FacingLeft = true;
            FacingRight = false;
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", true);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
            Navi3DAnimator.SetBool("NaviFallLeft", false);
            Navi3DAnimator.SetBool("NaviFallRight", true);

            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.RightShift) == true && FacingLeft == true && playerLocked == false && Input.GetKeyDown(KeyCode.D) == true)
        {

            FacingLeft = false;
            FacingRight = true;
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", true);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
            Navi3DAnimator.SetBool("NaviFallLeft", true);
            Navi3DAnimator.SetBool("NaviFallRight", false);

            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }


        ////////// Controls character switching from dashing animation to jumping when the player released the right shift key

        if (Input.GetKeyUp(KeyCode.RightShift) == true && FacingRight == true && playerLocked == false)
        {

            FacingRight = true;
            FacingLeft = false;
            Navi3DAnimator.SetBool("NaviFallLeft", false);
            Navi3DAnimator.SetBool("NaviFallRight", true);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);

            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyUp(KeyCode.RightShift) == true && FacingLeft == true && playerLocked == false)
        {
            FacingRight = false;
            FacingLeft = true;
            Navi3DAnimator.SetBool("NaviFallLeft", true);
            Navi3DAnimator.SetBool("NaviFallRight", false);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            

            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }


        //Controls which direction the character is facing.

        if (Input.GetKeyDown(KeyCode.A) == true && playerLocked == false)
        {

            FacingLeft = true; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = false;
            Navi3DAnimator.SetBool("NaviRunLeft", true);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);


        }

        if (Input.GetKeyDown(KeyCode.D) == true && playerLocked == false)
        {

            FacingLeft = false; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = true;
            Navi3DAnimator.SetBool("NaviRunRight", true);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);


        }

        if (Input.GetKeyDown(KeyCode.A) == true && playerLocked == false && OnFloor == true && dashLeft == false)
        {

            Navi3DAnimator.SetBool("NaviRunLeft", true);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.D) == true && playerLocked == false && OnFloor == true && dashRight == false)
        {

            Navi3DAnimator.SetBool("NaviRunRight", true);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }


        if (Input.GetKeyDown(KeyCode.D) == true && playerLocked == false)
        {

            FacingLeft = false; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = true;
            Navi3DAnimator.SetBool("NaviRunRight", true);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);


        }

        if (currentDashTime < maxDashTime) //If the current dash time is less than maxDashTime 

        {
            //moveDirection = new Vector3(0, 0, DashSpeed);
            //moveDirection = transform.forward * DashSpeed;
            moveDirection = new Vector3(-1, 0, 0 * DashSpeed);
            currentDashTime += PlayerDashStopSpeed;
            DashSpeed = 20;
            PlayerSpeed = 8;
            Debug.Log("Dashing");
            //playerAnimator.SetBool("PlayerDash", true); //This controls the sprite cversion of Navi
            Navi3DAnimator.SetBool("DashAttackActive", true);
            Navi3DAnimator.SetBool("DanceFalse", true);

        }

        if (currentDashTime > maxDashTime) //This gets called when dash speed goes higher than max dash time
        {
            DashSpeed = 0;
            //moveDirection = Vector3.zero;
            //Debug.Log("Slow dash");
            pressedDash = false;
            PlayerSpeed = 4;
        }




        if (Input.GetKeyUp(KeyCode.RightShift) == true && playerLocked == false) //if the shift key is up you're no longer dashing
        {
            pressedDash = false;
            DashSpeed = 0;
            PlayerSpeed = 4;
            print("Character stopped dashing");
            //playerAnimator.SetBool("PlayerDash", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            //Navi3DAnimator.SetBool("DanceFalse", true);
        }


        if (Input.GetKeyUp(KeyCode.RightShift) == true && playerLocked == true) //if the shift key is up you're no longer dashing
        {
           
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);

        }


        ///////////////DASHING CODE END ///////////////////


        if (FacingLeft == true)
        {
            FacingRight = false;
            //PlayerRB.transform.Rotate(0, -180, 0); //Rotates player 180 when running.
        }

        if (FacingRight == true)
        {
            FacingLeft = false;
            //PlayerRB.transform.Rotate(0, 0, 0); //Rotates player 180 when running.
        }


        if (Input.GetKey(KeyCode.A) == true && OnFloor == true && playerLocked == false) //Controls player moving left on the floor
        {
            print("Character moving left");
            PlayerRB.velocity = Vector2.left * PlayerSpeed;
            FacingLeft = true; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = false;
            print("Character facing left");
            walkingLeft = true;
            Navi3DAnimator.SetBool("NaviSpeed0", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviRunLeft", true);
        }

        if (Input.GetKey(KeyCode.A) == true && OnFloor == false && playerLocked == false && dashRight == false)
        {
            print("Character moving left in air");
            PlayerRB.velocity = Vector2.left * PlayerFallSpeed;
            verticalVelocity -= playerGravity * Time.deltaTime; //Makes player fall faster
            FacingLeft = true; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = false;
            print("Character facing left");
            walkingRight = true;
            Navi3DAnimator.SetBool("NaviFallLeft", true);
            Navi3DAnimator.SetBool("NaviRunRight", false);


        }


        //if (Input.GetKeyDown(KeyCode.D) == true && OnFloor)
        if (Input.GetKey(KeyCode.D) == true && OnFloor == true && playerLocked == false && dashLeft == false)
        {
            print("Character moving right");
            PlayerRB.velocity = Vector2.right * PlayerSpeed;
            verticalVelocity -= playerGravity * Time.deltaTime; //Makes player fall faster
            FacingLeft = false; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = true;
            print("Character falling left");
            Navi3DAnimator.SetBool("NaviRunRight", true);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            //playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed));
            // Navi3DAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed));

        }

        if (Input.GetKey(KeyCode.D) == true && OnFloor == false && playerLocked == false)
        {
            print("Character moving left in air");
            PlayerRB.velocity = Vector2.right * PlayerFallSpeed;
            FacingLeft = false; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = true;
            print("Character falling right");
           // Navi3DAnimator.SetBool("NaviFallLeft", false);
            Navi3DAnimator.SetBool("NaviFallRight", true);

        }

        if (Input.GetKey(KeyCode.D) == true && OnFloor == false && playerLocked == false)
        {
            print("Character moving right");
            PlayerRB.velocity = Vector2.right * PlayerSpeed;
            verticalVelocity -= playerGravity * Time.deltaTime; //Makes player fall faster
            FacingLeft = false; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = true;
            print("Character falling left");
            // playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed));
            //Navi3DAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed));
        }

        if (Input.GetKey(KeyCode.S) == true && OnFloor == false && playerLocked == false)
        {

            PlayerRB.velocity = Vector2.down * PlayerSpeed;
            verticalVelocity = -playerGravity * Time.deltaTime;
            print("Character pushing down in air");
            playerAirDown = true;
        }


        if (Input.GetKey(KeyCode.S) == true && OnFloor == false && pressedDash == true && playerLocked == false)
        {

            PlayerRB.velocity = Vector2.down * PlayerSpeed;
            verticalVelocity = -playerGravity * Time.deltaTime;
            print("Character dashing down");
            playerAirDown = true;


        }

        if (Input.GetKeyDown(KeyCode.A) == true && OnFloor == true && playerLocked == false)
        {

            print("Character pushing down on ground"); //This code controls the ground dash
            Navi3DAnimator.SetBool("NaviSpeed0", false);
        }

        if (Input.GetKeyDown(KeyCode.S) == true && OnFloor == true && playerLocked == false)
        {

            print("Character pushing down on ground"); //This code controls the ground dash
        }

        if (Input.GetKeyDown(KeyCode.A) == true && pressedDash == true && OnFloor == true && playerLocked == false)
        {
            print("Character dashing right");
            PlayerRB.velocity = Vector2.left * DashSpeed; //Controls dashing speed
                                                          //PlayerRB.velocity = Vector2.right * PlayerSpeed; //Controls running speed
            FacingLeft = true; //Tells you which way the player is facing.
            print("Character dashing left"); //This code controls the ground dash
            //Navi3DAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed)); 
            Navi3DAnimator.SetBool("NaviSpeed0", false);
            Navi3DAnimator.SetBool("NaviDashLeft", true);
            Navi3DAnimator.SetBool("NaviDashRight", false);
        }

        if (Input.GetKeyDown(KeyCode.D) == true && pressedDash == true && OnFloor == true && playerLocked == false)
        {
            print("Character dashing right");
            PlayerRB.velocity = Vector2.right * DashSpeed; //Controls dashing speed
                                                           //PlayerRB.velocity = Vector2.right * PlayerSpeed; //Controls running speed
            FacingLeft = true; //Tells you which way the player is facing.
            print("Character dashing right"); //This code controls the ground dash
            //Navi3DAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed)); 
            //Navi3DAnimator.SetBool("NaviSpeed0", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", true);
        }


        if (Input.GetKeyDown(KeyCode.A) == true && pressedDash == false && OnFloor == true && playerLocked == false)
        {
            Debug.Log("Navi running to the left");
            Navi3DAnimator.SetBool("NaviRunLeft", true);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            // Navi3DAnimator.SetBool("NaviSpeed0", false);
            Navi3DAnimator.SetBool("FacingLeft", true);
            Navi3DAnimator.SetBool("FacingRight", false);
            SoundManager.inst.PlaySound("NaviRun");
           
        }

        if (Input.GetKeyDown(KeyCode.D) == true && pressedDash == false && OnFloor == true && playerLocked == false)
        {
            Debug.Log("Navi running to the right");
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", true);
            //Navi3DAnimator.SetBool("NaviSpeed0", false);
            Navi3DAnimator.SetBool("FacingRight", true);
            Navi3DAnimator.SetBool("FacingLeft", false);
            SoundManager.inst.PlaySound("NaviRun");
        }



        if (pressedDash == true && FacingRight && playerLocked == false) //Controls speed when dashing to the right. 
        {
            print("Character dashing");
            PlayerRB.velocity = Vector2.right * DashSpeed;
            //playerAnimator.SetBool("PlayerDash", true);

            Navi3DAnimator.SetBool("DashAttackActive", true);
            //Navi3DAnimator.SetBool("DanceFalse", true);
            Navi3DAnimator.SetBool("NaviDashRight", true);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            SoundManager.inst.PlaySound("NaviDash");

        }

        if (pressedDash == true && FacingLeft && playerLocked == false) //Controls speed when dashing to the right. 
        {
            print("Character dashing");
            PlayerRB.velocity = Vector2.left * DashSpeed;
            //playerAnimator.SetBool("PlayerDash", true);
            Navi3DAnimator.SetBool("DashAttackActive", true);
            //Navi3DAnimator.SetBool("DanceFalse", true);
            //Navi3DAnimator.SetBool("NaviSpeed0", false);
            Navi3DAnimator.SetBool("NaviDashLeft", true);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            SoundManager.inst.PlaySound("NaviDash");

        }



        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true && playerLocked == false)
        {
            print("Character jumping");
            PlayerRB.velocity = Vector2.up * PlayerJumpSpeed; //Makes player jump
            //animator.SetBool("PlayerJump"), true);
           // Navi3DAnimator.SetBool("NaviSpeed0", false);


        }

        if (Input.GetKeyDown(KeyCode.W) && OnFloor == false)
        {
            print("Character cant jump");


        }

        //This code controls the player jumping left or right.

        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true && playerLocked == false && FacingLeft == true)
        {
            Navi3DAnimator.SetBool("NaviJumpLeft", true);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
            Navi3DAnimator.SetBool("FacingLeft", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true && playerLocked == false && FacingRight == true)
        {
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("NaviJumpRight", true);
            Navi3DAnimator.SetBool("FacingRight", true);
        }

        //Switching control player is facing

        if (Input.GetKeyDown(KeyCode.A) && OnFloor == false && playerLocked == false && FacingRight == true)
        {
            Navi3DAnimator.SetBool("NaviJumpRight", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", true);
            Navi3DAnimator.SetBool("FacingRight", false);
            Navi3DAnimator.SetBool("FacingLeft", true);
        }

        if (Input.GetKeyDown(KeyCode.D) && OnFloor == false && playerLocked == false && FacingLeft == true)
        {
            Navi3DAnimator.SetBool("NaviJumpRight", true);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("FacingRight", true);
            Navi3DAnimator.SetBool("FacingLeft", false);
        }


        if (Input.GetKeyDown(KeyCode.W) && pressedDash == true && playerLocked == false)
        {
            print("Character jumping");
            PlayerRB.velocity = Vector2.up * DashSpeed;
            //Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("Calling dance active in player movement, player speed set to 0");
            //playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed));
            //playerAnimator.SetBool("OnFloor", true);
            //Navi3DAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed));
            //Navi3DAnimator.SetBool("DanceFalse", true);
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            Navi3DAnimator.SetBool("CombatActive", false);
            Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("DashAttackActive", false);
            playerIsMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE UP!");
            // playerAnimator.SetBool("DanceUp", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceUP", true);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceANY", true);

        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {

            //playerAnimator.SetBool("DanceUp", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {

            //playerAnimator.SetBool("DanceDown", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {

            // playerAnimator.SetBool("DanceLeft", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {

            // playerAnimator.SetBool("DanceRight", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE DOWN!");
            //playerAnimator.SetBool("DanceDown", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", true);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceANY", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE LEFT!");
            //playerAnimator.SetBool("DanceLeft", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", true);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceANY", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE RIGHT!");
            // playerAnimator.SetBool("DanceRight", true);
            // Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", true);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
            Navi3DAnimator.SetBool("NaviDanceANY", true);
        }


        if (Input.GetKeyUp(KeyCode.UpArrow) == true)
        {

            //playerAnimator.SetBool("DanceUp", false);
            // Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
            // Navi3DAnimator.SetBool("NaviDanceANY", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) == true)
        {

            //playerAnimator.SetBool("DanceDown", false);
            // Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
            //Navi3DAnimator.SetBool("NaviDanceANY", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {

            //playerAnimator.SetBool("DanceRight", false);
            // Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {

            //playerAnimator.SetBool("DanceLeft", false);
            //Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) == false && Input.GetKeyDown(KeyCode.DownArrow) == false && Input.GetKeyDown(KeyCode.LeftArrow) == false && Input.GetKeyDown(KeyCode.RightArrow) == false && playerLocked == true)
        {
            Navi3DAnimator.SetBool("NaviDanceLEFT", false);
            Navi3DAnimator.SetBool("NaviDanceUP", false);
            Navi3DAnimator.SetBool("NaviDanceDOWN", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", false);
            Navi3DAnimator.SetBool("NaviDanceANY", false);
        }

        

        if (Input.GetKeyUp(KeyCode.A) == true)
        {
           
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            //Controls Navi running left and right stopping if the A key or the D key is released.
        }

        //Added 09/03/2022. Makes Navi go back to idle animation.
        if (Input.GetKeyUp(KeyCode.A) == true && OnFloor == true && dashLeft ==false && dashRight == false)
        {

            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            //Controls Navi running left and right stopping if the A key or the D key is released.
        }

        if (Input.GetKeyUp(KeyCode.D) == true)
        {

            Navi3DAnimator.SetBool("NaviRunRight", false);
            //Controls Navi running left and right stopping if the A key or the D key is released.
        }

        //Added 09/03/2022. Makes Navi go back to idle animation.
        if (Input.GetKeyUp(KeyCode.D) == true && OnFloor == true && dashLeft == false && dashRight == false)
        {

            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            //Controls Navi running left and right stopping if the A key or the D key is released.
        }


        if (Input.GetKeyUp(KeyCode.W) == true && Input.GetKeyUp(KeyCode.S) == true && Input.GetKeyUp(KeyCode.A) == true && Input.GetKeyUp(KeyCode.D) == true)
        {

            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);

        }

        if (Input.GetKeyUp(KeyCode.W) == true && Input.GetKeyUp(KeyCode.S) == true && Input.GetKeyUp(KeyCode.A) == true && Input.GetKeyUp(KeyCode.D) == true && Input.GetKeyUp(KeyCode.RightShift) == true)
        {

            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            //playerIsMoving = false;

        }

        if (Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.RightShift) == true || OnFloor == false)
        {

            Navi3DAnimator.SetBool("NaviSpeed0", false);
          //  playerIsMoving = true;

        }



        if (Input.GetKeyUp(KeyCode.RightShift) == true)
        {
            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
        }

        //Changes dash animation to fall animation if you release the shift key. 09/03/2022

        if (Input.GetKeyUp(KeyCode.RightShift) == true && FacingLeft == true && OnFloor == false)
        {
            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", true);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
        }


        if (Input.GetKeyUp(KeyCode.RightShift) == true && FacingRight == true && OnFloor == false)
        {
            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("NaviJumpRight", true);
        }



        if (Input.GetKeyDown(KeyCode.W) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.A) && pressedDash == false && playerLocked == false && OnFloor == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("NaviFallLeft", true);
            Navi3DAnimator.SetBool("NaviFallRight", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.D) && pressedDash == false && playerLocked == false && OnFloor == false)
        {
            //print("Character jumping");
            // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("NaviFallLeft", false);
            Navi3DAnimator.SetBool("NaviFallRight", true);
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.W) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        }

        if (Input.GetKeyDown(KeyCode.S) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviSpeed0", false);
            

        }

        /*
        if (playerIsMoving == false)
        {
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            Navi3DAnimator.SetBool("NaviRunRight", false);
            Navi3DAnimator.SetBool("NaviRunLeft", false);
            Navi3DAnimator.SetBool("NaviDashLeft", false);
            Navi3DAnimator.SetBool("NaviDashRight", false);
            Navi3DAnimator.SetBool("NaviFallUpLeft", false);
            Navi3DAnimator.SetBool("NaviFallUpRight", false);
            Navi3DAnimator.SetBool("NaviJumpLeft", false);
            Navi3DAnimator.SetBool("NaviJumpRight", false);
        }



        if (playerIsMoving == true)
        {
            Navi3DAnimator.SetBool("NaviSpeed0", false);

        } */
    }

    public void UnLockPlayer()
    {
        playerLocked = false;
    }

    public void LockPlayer()
    {
        playerLocked = true;
    }

    public void DanceActive()
    {

        if (playerLocked == true)
        {
            // transform.position = new Vector3(0, -2.41f, -1.4f);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ; //Freezes player in place
            playerLocked = true;
            PlayerSpeed = 0;
            Debug.Log("Calling dance active in player movement, player speed set to 0");

            //Resets players rotation to original position. Code added 11/01/2022
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            Navi3DAnimator.SetBool("CombatActive", false);
            Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviSpeed0", true);
            playerIsMoving = false;

        }



    }

    public void CombatActive()
    {


        playerLocked = false;
        //GetComponent<Rigidbody>().constraints = originalConstraints; //Sets constraints of player back to normal
        PlayerSpeed = 4;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeNone;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ; //Players constraints are unfrozen
        Debug.Log("Calling combat active in player movement, player speed set to 4");
        Navi3DAnimator.SetBool("DanceFalse", true);
        Navi3DAnimator.SetBool("CombatActive", true);
        //Navi3DAnimator.SetBool("NaviSpeed0", false);




    }
}







