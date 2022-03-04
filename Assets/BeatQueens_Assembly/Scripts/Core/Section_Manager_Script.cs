using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_Manager_Script : MonoBehaviour
{

    public bool DanceBegin;
    public bool FightBegin;
    public bool AttackModeActive;
    public GameObject CombatCollider;
    public GameObject HandleCollider;
   // public GameObject AttackManager;
    public GameObject PlayerTeleportGO;
    public GameObject Navi;
    public GameObject RedQueen;
    public GameObject EnemyHandGO;


    //This script is on the scroller handle object in the games HUD.
    //The below code controls the game objects that disable and enable the dance and attack scripts.

    // public GameObject BulletPool; // This game object has the BulletHellScript and it randomly spawns attacks.



    // Start is called before the first frame update

    void Start()
    {
        DanceBegin = true;
        FightBegin = false;
        AttackModeActive = false;


    }

    //Use this script to create a controller for the dance/action part of this game.
    //Player character must be forzen in place/teleported back to the middle of the stage when dance section begins. Their movement is locked.
    //Player must be able to move when action section begins.
    //At 40 seconds in dance section begins.

    // Update is called once per frame

    /*
    void Update()
    {
        if (DanceBegin == true)
        {
            Navi.GetComponent<PlayerMovement>().DanceActive();
            Debug.Log("Player frozen by DanceBegin true in section manager script");
            RedQueen.GetComponent<RedQueenScript>().DanceStart();// Launches Queen dance animations
        }



        if (FightBegin == true)
        {
            Navi.GetComponent<PlayerMovement>().CombatActive();
            Debug.Log("Player unfrozen by DanceBegin false in section manager script");
          //  AttackManager.GetComponent<BulletHellScript>().AttackSelection(); //Calls on code to launch attacks
            RedQueen.GetComponent<RedQueenScript>().QueenIdle(); // Queen stops dancing

        }



    }


    public void OnTriggerEnter(Collider CombatCollider) //When pellets collide with the player damage object they will dissapear and take points off the players score
    {

        Debug.Log("COMBAT SECTION HAS BEGUN! DANCE SECTION IS NOW OVER!");
       // AttackManager.GetComponent<BulletHellScript>().AttackSelection(); //Calls on code to launch attacks
        DanceBegin = false;
        FightBegin = true;
        AttackModeActive = true;
        Debug.Log("RELEASE PLAYER");
        RedQueen.GetComponent<RedQueenScript>().QueenIdle(); // Queen stops dancing
        EnemyHandGO.GetComponent<EnemyHandScript>().EnableHand();
       // AttackManager.GetComponent<BulletHellScript>().LaunchAttacks();

    }



    public void OnTriggerExit(Collider CombatCollider) //When pellets collide with the player damage object they will dissapear and take points off the players score
    {

        Debug.Log("COMBAT SECTION HAS ENDED! DANCE SECTION HAS BEGUN!");

        DanceBegin = true;
        FightBegin = false;
        PlayerTeleportGO.GetComponent<PlayerTeleportScript>().TeleportPlayer(); //Calls on PlayerTeleportScript to teleport the player
        Debug.Log("TELEPORT PLAYER");
        AttackModeActive = false;
       // AttackManager.GetComponent<BulletHellScript>().DestroyAllAttacks();
        RedQueen.GetComponent<RedQueenScript>().DanceStart();// Launches Queen dance animations
        EnemyHandGO.GetComponent<EnemyHandScript>().DisableHand();
       // AttackManager.GetComponent<BulletHellScript>().HaltAttacks();



    } */



}


