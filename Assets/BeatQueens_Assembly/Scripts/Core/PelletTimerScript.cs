using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletTimerScript : MonoBehaviour
{
    /*
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;
    */


    //This script destroys pellets after a set amount of time

    [Header("Private Variables")]
    private Vector3 startPoint;
    private const float radius = 1F;


    public float PelletTimeLeft = 3; //Value is set in inspector. Value for time pellets have left.
    public bool TimerActive;
    public bool PelletMade;
    public GameObject Pellet;
    public GameObject BBPellet;
  //  public bool PelletSpawnerActive;


    // Start is called before the first frame update
    void Start()
    {
        PelletTimeLeft = 3;
        //  PelletSpawnerActive = true;
        PelletMade = true;
    }


 

/*
    void PelletFire()
    {



        //The below code fires the pellets
       // startPoint = transform.position;
        //PelletFire(numberOfProjectiles);
    }
     */

public void PelletsExist()
    {
        PelletMade = true;

    }

    // Update is called once per frame
    void Update()
    {
     //   PelletSpawnerActive = true;

        if (Input.GetKey(KeyCode.L))
        {
            PelletsExist(); //Calls void to get pellets
            PelletMade = true;
            TimerActive = true;
        }

        if (PelletMade == true) //If a damage item has been made this code will run
        {
            TimerActive = true;
            PelletTimeLeft -= Time.deltaTime;
            if (PelletTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {
                Destroy(Pellet);
                //  Destroy(Bomb);
                Debug.Log("DESTROY PELLET");
                PelletMade = false;
                PelletTimeLeft = 3;
            }
        }
         
        //Fires due to start boolean

       


    } 
}
