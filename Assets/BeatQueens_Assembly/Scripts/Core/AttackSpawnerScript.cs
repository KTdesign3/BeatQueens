using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawnerScript : MonoBehaviour
{




    public GameObject BBPellet;
    public GameObject Bullet;
    public GameObject Pellet;


    public float DamageTimeLeft = 5; //Value is set in inspector
    public bool TimerActive;
    public bool spawnAllow;
    public bool spawnBullet;
    public bool spawnPellet;
    // Start is called before the first frame update
    void Start()
    {
        spawnAllow = true;
        DamageTimeLeft = 5;
    }



    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Damage").Length >= 10) //If there are more than or exactly 12 damage items on screen
        {

            spawnAllow = false; // Stop allowing these items to be instantiated
                                // Debug.Log("NO SPAWNING ALLOWED");

        }

        if (GameObject.FindGameObjectsWithTag("Damage").Length < 10) //If there are more than or exactly 12 damage items on screen
        {
            // Allow these items to be instantiated
            spawnAllow = true;
            // Debug.Log("SPAWNING ALLOWED");
            

        }



        //Below code controls the time before bullets are destroyed
        if (spawnAllow == true) //If a damage item has been made this code will run
        {
            TimerActive = true;
            DamageTimeLeft -= Time.deltaTime;
            OnBulletSpawn();
            OnPelletSpawn();
            if (DamageTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {


                Destroy(Bullet);
                Destroy(Pellet);
                Debug.Log("Timer ran out bullet self destructed");
                //spawnAllow = false;
                DamageTimeLeft = 5;
            }
        }

    }

    
    public void SpawnAllowCall()
    {
        spawnAllow = true;
       // spawnBullet = true;
       // spawnPellet = true;
        TimerActive = true;

    }

    public void SpawnAllowCallStop()
    {
        spawnAllow = false;
       // spawnBullet = false;
       // spawnPellet = false;
        TimerActive = false;
    }


    void OnPelletSpawn()
    {

        //myObject.GetComponent<MyScript>().MyFunction();
        //BulletPool.GetComponent<PelletAttackScript>().PelletFire(); //Calls pellet fire function in pellet script

        if (spawnAllow == true)
        {
           // damageMade = true; //Calls timer code to destroy pellet spawner after 5 seconds
            TimerActive = true;
            var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(5.0f, -1.0f), (-1.3f)); //This controls where the pellets spawn
          //  damageMade = true;
            for (int i = 0; i < 1; i++)
            {
                //
                Instantiate(Pellet, position, Quaternion.identity); // Instantiates 10 copies of Prefab each 2 units apart from each otherusing UnityEngine;
                spawnPellet = true;
            }
        }

        Debug.Log("Spawn pellets");

       // damageMade = true;
    }

    void OnBulletSpawn()
    {
        if (spawnAllow == true)
        {
            var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(5.0f, 5.0f), (-1.3f)); //X, Y and Z axis
            // transform.position += new Vector3(0, -1, 0) * Time.deltaTime; //This makes the bullets go down
            // Bullet.transform.position = new Vector3(0.0f, 4.0f, 0.0f); //Move down on y axis by 4
            // Bullet.velocity = transform.TransformDirection(Vector3.down * 10);
            // bulletSpeed = 20;


            for (int i = 0; i < 1; i++) //Spawns 5 bullets
            {

                // Instantiate(Bullet, new Vector3(i * -1, 5, -1.5f), Quaternion.identity); // Instantiates 5 copies of Prefab each 2 units apart from each otherusing UnityEngine;
                Instantiate(Bullet, position, Quaternion.identity); //This spawns the bullets
                spawnBullet = true;
                // transform.Translate(Vector3.down * 10 * Time.deltaTime);
                //damageMade = true;
                Debug.Log("Spawn bullets");


            }

            if (spawnBullet == true ||spawnPellet == true) //If a damage item has been made this code will run
            {
                TimerActive = true;
                DamageTimeLeft -= Time.deltaTime;
                if (DamageTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
                {

                    //Destroy(Bomb);
                    Destroy(Bullet);
                    Destroy(Pellet);
                    Debug.Log("Timer ran out bullet self destructed");
                   // damageMade = false;
                    DamageTimeLeft = 5;
                    spawnAllow = true;
                }
            }


        }
    }







}
