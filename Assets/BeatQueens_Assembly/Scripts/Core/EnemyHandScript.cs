using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandScript : MonoBehaviour
{

    //https://answers.unity.com/questions/690884/how-to-move-an-object-along-x-axis-between-two-poi.html
    private bool dirRight = true;
    public float speed = 2f;
    public GameObject EnemyHandGO;
    public bool EnemyHandActive;
    public GameObject Boundary;
    public GameObject PlayerDamage;
    public GameObject EnemyHeart;
    


    //New Code

    public GameObject EnemyDamageEnemyHandGO;

    //Corountine hand injure script
    public float EnemyHurtTime = 0f;
    [SerializeField] float startTime = 5f;


    //Enemy handpause code

    public float PauseTimeLeft = 2;
    public bool PauseTimerActive;
    public bool PauseActive;


    //Enemy idle code:

    public float IdleTimeLeft = 5f; //Value is set in inspector. 
    public bool IdleTimerActive;


    //Code related to enemy hand attacking player

    public Transform EnemyTarget;
    public Transform EnemyHandTransform;


    //Code related  to hand attack timer
    public float HandAttackTimeLeft = 3; //Value is set in inspector. Value for time pellets have left.
    public bool HandAttackTimerActive;
    //public bool BulletMade;


    //Code that changes hands color when attacking
    // [SerializeField] private Material AttackMat;
    public Material handMat;



    //Code related to resetting hands position
    public Transform EnemyHandPos;


    //
    public bool IdleActive;
    public bool AttackActive;


    private void Start()
    {
        transform.position = new Vector3(-4, 1, -1.3f);
        //transform.position = EnemyHandPos;
        //EnemyAttackingPlayer = false;
        EnemyHandActive = true;
        HandAttackTimerActive = false;
        IdleActive = true;


        //Added 14/01/2022
       // EnemyDamagePlayerGO.SetActive(false);
        EnemyDamageEnemyHandGO.SetActive(true);

    }




    //This will be called by the countdown script.

    public void StartHand()
    {
        //StartCoroutine(HandTimer());
        Debug.Log("Start everything has been called");

        //Calls countdown code from song countdown script.
        // SongCountdownTimerGO.GetComponent<SongCountdownScript>().SongCountdown(); 
    }




    void Update()
    {

       // if (IdleTimeLeft > 0 && IdleActive == true)
        {
            /*
            //Added by KS 14/01/2022
            EnemyDamageEnemyHandGO.SetActive(true);

            //Conditions

            IdleTimeLeft -= Time.deltaTime;
            //HandMoveCode();

            IdleTimerActive = true;

            //speed = 4f;
            speed = 4; */

            //Code that moves hand

            if (dirRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            else
                transform.Translate(-Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= 4.0f)
            {
                dirRight = false;
            }

            if (transform.position.x <= -4)
            {
                dirRight = true;
            }
        }

        /*
        //If the idle timer is less than 0 the idle timer is stopped and the hand attack code and timer is called.

        if (IdleTimeLeft < 0 && IdleTimerActive == true)
        {

            //HandAttack();
            IdleTimerActive = false;
            //SetAttackTime();
            SetHandPauseTime();
            speed = 2;

        }

        //If PauseTimeLeft is more than 0 do this
        if (PauseTimeLeft > 0 && PauseTimerActive == true)
        {
            PauseTimeLeft -= Time.deltaTime;
            //HandMoveCode();

            PauseTimerActive = true;
            handMat.color = Color.blue;
            EnemyDamageEnemyHandGO.SetActive(true);

        }

        //If PauseTimeLeft is less than 0 do this
        if (PauseTimeLeft < 0 && PauseTimerActive == true)
        {

            HandAttack();
            IdleTimerActive = false;
            SetAttackTime();
            // HandAttackTimerActive = true;
            PauseTimerActive = false;
            PauseActive = false;
            speed = 10;



        }

        //If HandAttackTimeLeft is more than 0 do this
        if (HandAttackTimeLeft > 0 && HandAttackTimerActive == true)
        {
            HandAttackTimeLeft -= Time.deltaTime;
            HandAttackTimerActive = true;
            AttackActive = true;
            HandAttack();
            handMat.color = Color.magenta;

            //Added by KS 14/01/2022
            //The player cannot damage the enemy and the enemy can damage the player on contact
            EnemyDamagePlayerGO.SetActive(true);
            EnemyDamageEnemyHandGO.SetActive(false);

        }

        //If HandAttackTimeLeft is less than 0 do this
        if (HandAttackTimeLeft <= 0 && HandAttackTimerActive == true) //If hand attack time is less than 0, set hand to idle
        {
            //HandMoveCode();
            //IdleTimerActive = false;
            SetIdleTime();
            HandAttackTimerActive = false;
            Debug.Log("Attack has ended, return to idling.");
            handMat.color = Color.red;
            speed = 4;

            //Added by KS 14/01/2022
            //If the enemy is not attacking the enemy cannot damage the player on contact and the player can damage the enenmy
            EnemyDamagePlayerGO.SetActive(false);
            EnemyDamageEnemyHandGO.SetActive(true);

        }

        

        if(AttackActive == true)
        {
            Debug.Log("Enemy can now harm the player!");
            PlayerDamage.GetComponent<PlayerScore>().HarmPlayer();
            
        }

        if (AttackActive == false)
        {
            Debug.Log("Enemy can't harm the player!");
            PlayerDamage.GetComponent<PlayerScore>().ProtectPlayer();
        } */



    }



    /*
    public void HandMoveCode()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 4.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -4)
        {
            dirRight = true;
        }

    } */

    public void EnableHand()
    {
        EnemyHandGO.SetActive(true);
        Debug.Log("Hand active");
        //Enabled hand during combat mode
        EnemyHandActive = true;
        // HandIdle(); //Calls hand idle function

    }


    public void DisableHand()
    {
        EnemyHandGO.SetActive(true);
        Debug.Log("Hand inactive");
        //Disabled hand during dance mode
        EnemyHandActive = false;
    }

    /*
    public void HandAttack()
    {
        //The below code makes the hand attack the gameobject with the target transform attached to it.
        //HandAttackTimerActive = true;
        transform.LookAt(EnemyTarget);
        transform.Translate(Vector3.forward * 3 * Time.deltaTime);

        // transform.Translate(Vector3.down * 5 * Time.deltaTime);
        //Hand attacking


        //Added by KS 14/01/2022
        
       

    } 

    public void SetIdleTime()
    {
        IdleTimeLeft = 5;
        IdleActive = true;
        transform.position = new Vector3(-4, 1, -1.3f);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);


        IdleTimerActive = true;
        PauseTimerActive = false;
        AttackActive = false;
        //speed = 5f;
    }

    public void SetHandPauseTime()
    {
        PauseTimeLeft = 2;


        PauseTimerActive = true;
        IdleTimerActive = false;

        IdleActive = false;
        PauseActive = true;
        AttackActive = false;
        //transform.position = new Vector3(-4, 1, -1.3f);
        // transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        // speed = 2f;
    }

    public void SetAttackTime()
    {
        HandAttackTimeLeft = 5;
        HandAttackTimerActive = true;
        PauseTimerActive = false;
        IdleTimerActive = false;

        IdleActive = false;
        PauseActive = false;
        AttackActive = true;
        //speed = 10f;
    } */

    public void ResetHandPos()
    {
        Debug.Log("Hand outside of bounds.");



        //Resets position of hand
        transform.position = new Vector3(-4, 1, -1.3f);

        //Resets rotation of hand
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
    }

    
    private void OnTriggerEnter(Collider other)
    {

        //This code resets the hands position to the idle position if it collides with the player

        if (other.gameObject.tag == "HandContainer")
        {
            ResetHandPos();

        }


        if (other.gameObject.tag == "PlayerDamage")
        {
            Debug.Log("Player dashed into EnemyHandScript, deducting points from enemy hand");
            EnemyScoreScript.EnemyScoreValue -= 50;
            SoundManager.inst.PlaySound("HeartTakeDamage");
            //HurtColorChangeScript.Injury
            // GetComponent<HurtColorChangeScript>().Injury();
            //GetComponent<DamageFlashScript>().EFlash();
            EnemyHeart.GetComponent<DamageFlashScript>().AttackFlash();
        }

        

        /*
        if (other.gameObject.tag == "PlayerDamage" && AttackActive == true)
        {

            Debug.Log("Hand hit the player, deducting points from player script");
            PlayerDamage.GetComponent<PlayerScore>().HarmPlayer();


        } */

    }


    

}
