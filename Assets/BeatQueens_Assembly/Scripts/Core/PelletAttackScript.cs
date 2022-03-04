using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletAttackScript : MonoBehaviour
{

    //This code controls how pellets are fired (amount of pellets and formation) and the time left until the prefab is made.
    //This iscript is for controlling the pellets. The Pellet timer script is for controlling how long the pellet timer is on screen for.

    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;

    [Header("Private Variables")]
    private Vector3 startPoint;
    private const float radius = 1F;


    //Below code controls pellet timer (aka timer that destroys yell)
    public float PelletTimeLeft = 5; //Value is set in inspector. Value for time pellets have left.
    public bool PelletTimerActive;
    public bool PelletMade;
    public GameObject Pellet;
    public bool PelletSpawned;


    //Below code controls when pellets fire
    public float PelletFireTime = 0;
    public float PelletFireCap = 1.5f;


    void Start()
    {
        PelletTimerActive = true;
        PelletFireTime = 0;
        PelletSpawned = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            startPoint = transform.position;
            PelletFire(numberOfProjectiles);
            // SpawnProjectile(int numberOfProjectiles);
            // SpawnProjectile = numberOfProjectiles;
            //GetComponent<PelletTimerScript>().PelletsExist(); //Call pellet timer script void
            PelletMade = true;
        }

        //Controls code that will destroy pellet object


        //I think this block will cause the code to fire once every 1.5 seconds
        if (PelletSpawned == true)
        {
            // startPoint = transform.position;
            //PelletFire(numberOfProjectiles);
            PelletFireTime += Time.deltaTime;
            if (PelletFireTime <= 1.5f) //If PelletFireTime is larger than 1.5 seconds run the below code
            {
                //Controls code that will fire pellets once every second.

                startPoint = transform.position;
                PelletFire(numberOfProjectiles);
                PelletMade = true;
                PelletFireTime = 0;
                PelletSpawned = false;
            }
        }


        if (PelletMade == true) //If a damage item has been made this code will run
        {
            
            PelletTimerActive = true;
            PelletTimeLeft -= Time.deltaTime;
            if (PelletTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {

                
                Destroy(Pellet);
                Debug.Log("Timer ran out bullet self destructed");
                PelletMade = false;
                PelletTimeLeft = 5;
            }


            PelletFireTime +=  Time.deltaTime;
            if (PelletFireTime <= 1.5f) //If PelletFireTime is larger than 1.5 seconds run the below code
            {
                //Controls code that will fire pellets once every second.

                startPoint = transform.position;
                PelletFire(numberOfProjectiles);
                PelletMade = true;
                PelletFireTime = 0;
            }
        }


        
    }


    private void OnTriggerEnter(Collider other) //When pellets collide with the player damage object they will dissapear and take points off the players score
    {
        Destroy(gameObject); //Destroys pellet
        //Player score script has been added to player damage. This will take away points from the player after colliding with a pellet.
        Debug.Log("Pellet has collided with player. Destroy pellet.");


    }

    //The below script controls the pellets firing.
    public void PelletFire(int numberOfProjectiles)
    {
        PelletMade = true;
        

        float angleStep = 360f / numberOfProjectiles; //Makes it shoot out in a circle all around the object
        float angle = 00f; //ORIGINALLY 0

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {

            //Direction calculations
            //float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0); //The positioning of this effects the values

            angle += angleStep;

            ///Tutorial used for this coding: https://www.youtube.com/watch?v=P20DQj1l4jw

        }


        //float bullDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
        // float bullDirY = transform.position.y + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);


    }
}
