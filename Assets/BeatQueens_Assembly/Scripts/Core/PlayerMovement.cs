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
    public bool playerAirDown;
    public float maxDashTime = 5; //Controls length of dash so you cant dash continuously.
    public float currentDashTime = 0;
    private float playerGravity = 14.0f;
    private float verticalVelocity;
    public Vector3 moveDirection;
    //private int direction;


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
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ; //Players constraints are unfrozen


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
        //////////DASHING CODE START ///////////////////
        ///


        if (PlayerSpeed < 0.01)
        {
            
                Navi3DAnimator.SetBool("NaviSpeed0", true);
        }

        if (PlayerSpeed > 0.01)
        {

            Navi3DAnimator.SetBool("DashAttackActive", false);
            Navi3DAnimator.SetBool("NaviSpeed0", true);
        }


        if (OnFloor == true)
        {
            Navi3DAnimator.SetBool("NaviOnGround", true);
        }

        if (OnFloor == false)
        {
            Navi3DAnimator.SetBool("NaviOnGround", false);
        }


        if (Input.GetKeyDown(KeyCode.RightShift) == true && playerLocked == false)
        {
            pressedDash = true;
            currentDashTime = 0;
            print("Character dashing");

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
            Navi3DAnimator.SetBool("DashAttackActive", false);
            //Navi3DAnimator.SetBool("DanceFalse", true);
        }


        ///////////////DASHING CODE END ///////////////////





        if (Input.GetKey(KeyCode.A) == true && OnFloor && playerLocked == false) //Controls player moving left on the floor
        {
            print("Character moving left");
            PlayerRB.velocity = Vector2.left * PlayerSpeed;
            FacingLeft = true; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = false;
            print("Character facing left");
            walkingLeft = true;

        }

        if (Input.GetKey(KeyCode.A) == true && OnFloor == false && playerLocked == false)
        {
            print("Character moving left in air");
            PlayerRB.velocity = Vector2.left * PlayerFallSpeed;
            verticalVelocity -= playerGravity * Time.deltaTime; //Makes player fall faster
            FacingLeft = true; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = false;
            print("Character facing left");
            walkingRight = true;

        }


        //if (Input.GetKeyDown(KeyCode.D) == true && OnFloor)
        if (Input.GetKey(KeyCode.D) == true && OnFloor && playerLocked == false)
        {
            print("Character moving right");
            PlayerRB.velocity = Vector2.right * PlayerSpeed;
            verticalVelocity -= playerGravity * Time.deltaTime; //Makes player fall faster
            FacingLeft = false; //Tells you which way the player is facing. IMPORTANT FOR DASHING IN THE RIGT DIRECTION.
            FacingRight = true;
            print("Character falling left");
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

        }

        if (Input.GetKey(KeyCode.D) == true && OnFloor && playerLocked == false)
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


        if (Input.GetKeyDown(KeyCode.S) == true && OnFloor == true && playerLocked == false)
        {

            print("Character pushing down on ground"); //This code controls the ground dash
        }

        if (Input.GetKeyDown(KeyCode.D) == true && pressedDash == true && OnFloor == true && playerLocked == false)
        {
            print("Character dashing right");
            PlayerRB.velocity = Vector2.right * DashSpeed; //Controls dashing speed
                                                           //PlayerRB.velocity = Vector2.right * PlayerSpeed; //Controls running speed
            FacingLeft = true; //Tells you which way the player is facing.
            print("Character dashing right"); //This code controls the ground dash
            //Navi3DAnimator.SetFloat("PlayerSpeed", Mathf.Abs(PlayerSpeed)); 
            Navi3DAnimator.SetBool("NaviSpeed0", false);
        }



        if (pressedDash == true && FacingRight && playerLocked == false) //Controls speed when dashing to the right. 
        {
            print("Character dashing");
            PlayerRB.velocity = Vector2.right * DashSpeed;
            //playerAnimator.SetBool("PlayerDash", true);

            Navi3DAnimator.SetBool("DashAttackActive", true);
            //Navi3DAnimator.SetBool("DanceFalse", true);


        }

        if (pressedDash == true && FacingLeft && playerLocked == false) //Controls speed when dashing to the right. 
        {
            print("Character dashing");
            PlayerRB.velocity = Vector2.left * DashSpeed;
            //playerAnimator.SetBool("PlayerDash", true);
            Navi3DAnimator.SetBool("DashAttackActive", true);
            //Navi3DAnimator.SetBool("DanceFalse", true);


        }



        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true && playerLocked == false)
        {
            print("Character jumping");
            PlayerRB.velocity = Vector2.up * PlayerJumpSpeed; //Makes player jump
            //animator.SetBool("PlayerJump"), true);
            


        }

        if (Input.GetKeyDown(KeyCode.W) && OnFloor == false)
        {
            print("Character cant jump");


        }

        if (Input.GetKeyDown(KeyCode.W) && pressedDash == true && playerLocked == false)
        {
            print("Character jumping");
            PlayerRB.velocity = Vector2.up * DashSpeed;

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
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE UP!");
            // playerAnimator.SetBool("DanceUp", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceUP", true);

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
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE LEFT!");
            //playerAnimator.SetBool("DanceLeft", true);
            //  Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceLEFT", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerLocked == true)
        {
            PlayerSpeed = 0;
            Debug.Log("DANCE RIGHT!");
            // playerAnimator.SetBool("DanceRight", true);
            // Navi3DAnimator.SetBool("DanceFalse", false);
            Navi3DAnimator.SetBool("NaviDanceRIGHT", true);
        }


        if (Input.GetKeyUp(KeyCode.UpArrow) == true)
        {

            //playerAnimator.SetBool("DanceUp", false);
           // Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) == true)
        {

            //playerAnimator.SetBool("DanceDown", false);
           // Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {

            //playerAnimator.SetBool("DanceRight", false);
           // Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {

            //playerAnimator.SetBool("DanceLeft", false);
            //Navi3DAnimator.SetBool("DanceFalse", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);

        }

        if (Input.GetKeyDown(KeyCode.W) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);

        }

        if (Input.GetKeyDown(KeyCode.W) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);

        }

        if (Input.GetKeyDown(KeyCode.S) && pressedDash == false && playerLocked == false)
        {
            //print("Character jumping");
           // PlayerRB.velocity = Vector2.up * DashSpeed;
            Navi3DAnimator.SetBool("DashAttackActive", false);

        }


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







