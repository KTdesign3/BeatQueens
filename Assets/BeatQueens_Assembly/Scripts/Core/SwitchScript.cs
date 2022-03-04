using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    public GameObject orb1;
    public GameObject orb2;
    public bool spawnOrb1; //Sets value to make an orb true
    public bool spawnOrb2;
    public bool Orb1TimerActive; //
    public bool Orb2TimerActive;
    public float OrbExplosionLeft = 5;
    public float Orb2ExplosionLeft = 5;
    public float Orb1TimerLeft = 3; //Tie until orb goes away
    public float Orb2TimerLeft = 3;
    public bool orb1Destroyed;
    public bool orb2Destroyed;
    public bool spawnAllow = true; //This controls whether damage items can spawn or not based on the amount of damage items.
    public bool callOrb2; //Allows orb 2 to be called after orb 1 is destroyed. Set back to false after 1 orb has been called.
    // Start is called before the first frame update
    Vector3 orb1Pos;

    void Start()
    {
        spawnOrb1 = false;
        spawnOrb2 = false;
        Orb1TimerActive = false;
        Orb2TimerActive = false;
        orb1Destroyed = false;
        orb2Destroyed = false;
        // Orb1TimerLeft = 3;
        // Orb2TimerLeft = 3;
        OrbExplosionLeft = 5;
        Orb2ExplosionLeft = 5;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Damage").Length >= 20) //If there are more than or exactly 12 damage items on screen
        {

            spawnAllow = false; // Stop allowing these items to be instantiated
                                // Debug.Log("NO SPAWNING ALLOWED");

        }

        if (GameObject.FindGameObjectsWithTag("Damage").Length < 20) //If there are more than or exactly 12 damage items on screen
        {
            // Allow these items to be instantiated
            spawnAllow = true;
            // Debug.Log("SPAWNING ALLOWED");

        }



        if (Input.GetKeyDown(KeyCode.O) == true) //Calls code to spawn an orb
        {

            spawnOrb1 = true; //This starts the timer code

            OnOrbSpawn();

            Debug.Log("Spawned orb 1");
        }

        if (spawnOrb1 == true) //If a damage item has been made this code will run
        {
            Orb1TimerActive = true;
            Orb1TimerLeft -= Time.deltaTime;
            if (Orb1TimerLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {

                Destroy(orb1);
                //Destroy(Bullet);
                // Destroy(Pellet);

                Debug.Log("Orb 1 destroyed");
                spawnOrb1 = false;
                Orb1TimerLeft = 5;
                orb1Destroyed = true; //This allows you to call orb2spawn
                callOrb2 = true;
            }
        }


        if (orb1Destroyed == true && callOrb2 == true)
        {

            Orb2Spawn();

        }


        // Instantiate(orb2, position, Quaternion.identity); // Instantiates 5 copies of Prefab each 2 units apart from each otherusing UnityEngine;
        //private Transform orb1Pos;
        // Instantiate(orb2, orb1Pos.position, Quaternion.identity); // Instnatiated object in orb 1 pos

        // var orb1Pos = GameObject.Find("orb1").transform.position; //Finds orb 1 position


        //var orb1Pos = GameObject.Find("orb1").transform.position; //Finds orb 1 position


        orb1Pos = orb1.transform.position;
        //Debug.Log("THIS FINDS ORB 1'S POSITION");

    }



    void OnOrbSpawn()
    {
        if (spawnOrb1 == true && spawnAllow == true)
        {
            Orb1TimerActive = true;

            var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(5.0f, 5.0f), (-1.3f)); //X, Y and Z axis
            for (int i = 0; i < 1; i++) //Spawns 5 bullets
            {

                Instantiate(orb1, position, Quaternion.identity); // Instantiates 5 copies of Prefab each 2 units apart from each otherusing UnityEngine;
                spawnOrb1 = true;
                // transform.Translate(Vector3.down * 10 * Time.deltaTime);
                Debug.Log("Spawn bullets");


            }


            if (spawnOrb1 == true) //If a damage item has been made this code will run
            {
                Orb1TimerActive = true;
                Orb1TimerLeft -= Time.deltaTime;
                if (Orb1TimerLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
                {
                    // orb1.SetActive = false;
                    // orb1.SetActive(false);
                    //   orb1Destroyed = true;
                    Destroy(orb1);

                    Instantiate(orb2, position, Quaternion.identity); // Instantiates 5 copies of Prefab each 2 units apart from each otherusing UnityEngine;
                    spawnOrb2 = true;
                    orb1Destroyed = true;

                }

                if (orb1Destroyed == true) //If a damage item has been made this code will run
                {

                    Orb2Spawn();

                    Debug.Log("Destroyed orb1");


                }


            }
        }
    }



    void Orb2Spawn()
    {

        if (orb1Destroyed == true)
        {
            Orb2TimerActive = true;

            //  var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(5.0f, 5.0f), (-1.3f)); //X, Y and Z axis
            for (int i = 0; i < 1; i++) //Spawns 5 bullets
            {

                // Instantiate(orb2, position, Quaternion.identity); // Instantiates 5 copies of Prefab each 2 units apart from each otherusing UnityEngine;
                spawnOrb2 = true;
                // transform.Translate(Vector3.down * 10 * Time.deltaTime);
                //Instantiate(orb2, orb1Pos.position, Quaternion.identity); // Instnatiated object in orb 1 pos
                Instantiate(orb2, orb1Pos, Quaternion.identity); // Instnatiated object in orb 1 pos
                Debug.Log("SPAWN ORB 2");

                callOrb2 = false;
                Debug.Log("RUN THE DAMN CALLORB2 CODE");



            }

            if (spawnOrb2 == true) //If a damage item has been made this code will run
            {
                Orb2TimerActive = true;
                Orb2TimerLeft -= Time.deltaTime;
                if (Orb2TimerLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
                {
                    // orb1.SetActive = false;
                    orb2.SetActive(false);
                    orb2Destroyed = true;
                    Destroy(orb2);
                    // Destroy(orb2);
                    spawnOrb2 = false;

                }

                if (orb2Destroyed == true) //If a damage item has been made this code will run
                {

                    //  Orb2Spawn();

                    Destroy(orb2);

                    Debug.Log("DESTROY ORB 2");


                }


            }
        }


        

    }
}











