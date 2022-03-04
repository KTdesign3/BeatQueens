using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialAttackScript : MonoBehaviour
{
    // private Vector2 bulletMoveDirection;
    //private float angle = 0f;

    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;

    [Header("Private Variables")]
    private Vector3 startPoint;
    private const float radius = 1F;

    // This code controls when the bullets are fired. 
    public bool PelletSpawnerActive;
    public float CurrentPelletTime = 1.5f;
    public float PelletTimeLeft = 1.5f;
    public bool FirePelletTimerActive = true;

    private void Start()
    {
        PelletSpawnerActive = true;
        FirePelletTimerActive = true;
    }


    public void PelletStop()
    {
        PelletSpawnerActive = false;
    }

    public void PelletStart()
    {
        PelletSpawnerActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            startPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
            // SpawnProjectile(int numberOfProjectiles);
           // SpawnProjectile = numberOfProjectiles;
        }

        PelletSpawnerActive = true;
        FirePelletTimerActive = true;

        /*
        TimerActive = true;
        var position = new Vector3(Random.Range(-9.0f, 8.0f), Random.Range(4.0f, -1.0f), (-1.3f)); //This controls where the bullets spawn
        damageMade = true;
        for (int i = 0; i < 1; i++)
        {
            //
            Instantiate(Pellet, transform.position, Quaternion.identity); // Instantiates 10 copies of Prefab each 2 units apart from each otherusing UnityEngine;
            spawnPellet = true;
        } */

        if (PelletSpawnerActive == true) //If a damage item has been made this code will run
        {
            FirePelletTimerActive = true;
            PelletTimeLeft -= Time.deltaTime;
            if (PelletTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {
                startPoint = transform.position;
                SpawnProjectile(numberOfProjectiles); //This will call pellets to be spawned every 2 seconds
                PelletTimeLeft = 1.5f;

                Debug.Log("Pellets spawned");
            }
        }

    }


    private void SpawnProjectile(int numberOfProjectiles)
    {

        float angleStep = 360f / numberOfProjectiles; //Makes it shoot out in a circle all around the object
        float angle = 00f; //ORIGINALLY 0

        for (int i = 0; i <= numberOfProjectiles -1; i++)
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