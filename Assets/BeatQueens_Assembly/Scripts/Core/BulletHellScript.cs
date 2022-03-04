using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BulletHellScript : MonoBehaviour
{


    public float bulletSpeed = 20.0f;
    public Transform Target;
    public Vector3 startPosition;
    // public bool combatMode;
    public GameObject BBPellet;
    public GameObject Bullet;
    public GameObject Bomb;
    public GameObject Pellet;
    public float DamageTimeLeft = 5; //Value is set in inspector
    public bool TimerActive;
    public bool BombTimer;
    public float BombTimeLeft = 3;
    public GameObject BombExplo;
    //public GameObject BulletPool;
    public GameObject AttackManager;
    public bool damageMade = true;
    public bool spawnBullet;
    public bool spawnBomb;
    public bool spawnPellet;
    public float damageMax = 12;
    public static int damageNumber = 0;
    public Text damageText;
    public bool spawnAllow = true; //This controls whether damage items can spawn or not based on the amount of damage items.



    //The below code had to do with randomly selecting an attack to spawn during the attack stage.

   // public int RandomAttack = Random.Range(1, 4); //Between 1 and 3. There is no fourth attack. CODE I JUST BLANKED
    public bool AttackAllowed = false;
    public float AttackTimer = 5;
    public float AttackTimerLeft = 5;



    //New code to do with launching attacks
    public bool CombatLaunch;
    public bool CombatTrue;
    public float AttackLaunchTimer = 0; //Float that launches attack after 3 seconds


    // Start is called before the first frame update
    void Start()
    {
        DamageTimeLeft = 5;
        bulletSpeed = 20;
        //  AttackSelection(); //This is needed to avoid the following error https://stackoverflow.com/questions/41833512/randomrangeint-is-not-allowed-to-be-called-from-a-monobehavior-constructor
        AttackAllowed = false; //Controls whether attacks are allowed

    }


    //The following code inside of AttackSelection controls what case is launched depending on 

    public void AttackSelection()
    {
        switch (Random.Range(0, 2)) //returns either 0 or 1



        // switch (RandomAttack)
        {
            case 2:

                OnBombSpawn();

                print("Bomb attack has been selected!");


                break;

            case 1:

                OnPelletSpawn();

                print("Pellet attack has been selected!");


                break;

            default:

                OnBulletSpawn();

                print("Bullet rain attack has been selected!");


                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GameObject.FindGameObjectsWithTag("Damage").Length >= 5) //If there are more than or exactly 12 damage items on screen
        {

            spawnAllow = false; // Stop allowing these items to be instantiated
                                // Debug.Log("NO SPAWNING ALLOWED");

        } */

        /*

        if (GameObject.FindGameObjectsWithTag("Damage").Length < 5) //If there are more than or exactly 12 damage items on screen
        {
            // Allow these items to be instantiated
            spawnAllow = true;
            // Debug.Log("SPAWNING ALLOWED");

        } */

        if (GameObject.FindGameObjectsWithTag("Bullet").Length < 5) //If there are more than or exactly 12 damage items on screen
        {
            // Allow these items to be instantiated
            spawnAllow = true;
            // Debug.Log("SPAWNING ALLOWED");

        }

       
        if (GameObject.FindGameObjectsWithTag("PelletSpawner").Length < 5) //If there are more than or exactly 12 damage items on screen
        {
            // Allow these items to be instantiated
            spawnAllow = true;
            // Debug.Log("SPAWNING ALLOWED");

        }

        if (GameObject.FindGameObjectsWithTag("PelletSpawner").Length > 6) //If there are more than or exactly 12 damage items on screen
        {
            // Allow these items to be instantiated
            spawnAllow = false;
            // Debug.Log("SPAWNING ALLOWED");

        }

        if (GameObject.FindGameObjectsWithTag("Bullet").Length >= 7) //If there are more than or exactly 12 damage items on screen
        {

            spawnAllow = false; // Stop allowing these items to be instantiated
                                // Debug.Log("NO SPAWNING ALLOWED");

        }

        if (Input.GetKeyDown(KeyCode.R) == true) //Spontaneously spawns bullets along top row
        {

            OnBulletSpawn();
            bulletSpeed = 20;


        }

        if (Input.GetKeyDown(KeyCode.T) == true) //Spawns bullets that will fall down from sky.
        {
            OnBombSpawn();
            // bombSpeed = 20;

        }

        if (Input.GetKeyDown(KeyCode.Y) == true) //Spawns bullets that will fall down from sky.
        {

            OnPelletSpawn();
            //OnExplosionSpawn();
            // pelletSpeed = 20;

        }


        



        //Below code controls the time before bullets are destroyed
        if (damageMade == true) //If a damage item has been made this code will run
        {
            TimerActive = true;
            DamageTimeLeft -= Time.deltaTime;
            if (DamageTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {

               // Destroy(Bomb);
               // Destroy(Bullet);
                Destroy(Pellet);
                Debug.Log("Timer ran out bullet self destructed");
                damageMade = false;
                DamageTimeLeft = 5;
            }
        }




        //Below code controls the time before bullets are destroyed
        if (AttackAllowed == true) //If a damage item has been made this code will run
        {
            //AttackTimer = true;
            AttackTimerLeft -= Time.deltaTime;
            if (AttackTimerLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {

                Debug.Log("Time left");
                AttackTimerLeft = 5;
            }
        }


        ///New code to make attacks fire in game build
        ///

        




        if (CombatTrue == true)
        {

            CombatLaunch = true;
        }

        if (CombatTrue == false)
        {

            CombatLaunch = false;
        }

        if (CombatLaunch == true) //This code
        {
            //AttackTimer = true;
            AttackLaunchTimer += Time.deltaTime;
            if (AttackLaunchTimer >= 2) //This will add 5 to
            {
                //EnemyScoreScript.EnemyScoreValue += 5;
                AttackSelection();
                Debug.Log("Launched 1 attack");
                AttackLaunchTimer = 0;
            }
        }







    }


    //The launchattacks void enables combat mode attacks
    public void LaunchAttacks()
    {
        CombatTrue = true;
        Debug.Log("Combat mode enabled");
    }

    public void HaltAttacks()
    {
        CombatTrue = false;
        Debug.Log("Combat mode disabled");
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
                damageMade = true;
                Debug.Log("Spawn bullets");


            }

            if (spawnBullet == true) //If a damage item has been made this code will run
            {
                TimerActive = true;
                DamageTimeLeft -= Time.deltaTime;
                if (DamageTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
                {

                    //Destroy(Bomb);
                    Destroy(Bullet);
                    Destroy(Pellet);
                    Debug.Log("Timer ran out bullet self destructed");
                    damageMade = false;
                    DamageTimeLeft = 5;
                }
            }


        }

    }

    void OnBombSpawn()
    {
        if (spawnAllow == true)
        {
            TimerActive = true;
            var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(5.0f, -1.0f), (-1.3f)); //This controls where the bullets spawn
            for (int i = 0; i < 1; i++)
            {
                Instantiate(Bomb, position, Quaternion.identity); //This spawns the bullets
                spawnBomb = true;
                //BombTimer BombTimeLeft
            }

        }

        if (spawnBomb == true) //If a bomb has been spawned this code will play
        {
            BombTimer = true;
            BombTimeLeft -= Time.deltaTime;
            if (BombTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {

                OnExplosionSpawn();
                /*
                 

                Instantiate(BombExplo, transform.position, Quaternion.identity); //This spawns the game object called BombExplo
                Bomb.SetActive(false);
                BombExplo.SetActive(true);
                Debug.Log("Bomb explosion occured");
                damageMade = false;
                BombTimeLeft = 5;
                GetComponent<BombMoverScript>().BombGone(); */

            }
        }

        Debug.Log("Spawn bomb");

        damageMade = true;
    }


    void OnExplosionSpawn()
    {
        Instantiate(BombExplo, transform.position, Quaternion.identity); //This spawns the game object called BombExplo
    }


    void OnPelletSpawn()
    {

        //myObject.GetComponent<MyScript>().MyFunction();
        //BulletPool.GetComponent<PelletAttackScript>().PelletFire(); //Calls pellet fire function in pellet script

        if (spawnAllow == true)
        {
            damageMade = true; //Calls timer code to destroy pellet spawner after 5 seconds
            TimerActive = true;
            var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(5.0f, -1.0f), (-1.3f)); //This controls where the pellets spawn
            damageMade = true;
            for (int i = 0; i < 1; i++)
            {
                //
                Instantiate(Pellet, position, Quaternion.identity); // Instantiates 10 copies of Prefab each 2 units apart from each otherusing UnityEngine;
                spawnPellet = true;
            }
        }

        Debug.Log("Spawn pellets");

        damageMade = true;
    }

    public void DestroyAllAttacks()
    {


        spawnAllow = false; //Doesn't allow damage objects to spawn and destroys all on scren
        Destroy(Bomb);
        Destroy(Bullet);
        Destroy(Pellet);
        Destroy(BBPellet);
        Debug.Log("Destroy all damage objects once dance begins starts");
        DamageTimeLeft = 0;

    }




    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player") //This tag is on damage items. When the player collides with a damage item they will lose score.
        {

            Destroy(gameObject);
            Debug.Log("Damage item has collided with player. Destroy object.");
        }

        if (collision.gameObject.tag == "Boundary") //This tag is on damage items. When the player collides with a damage item they will lose score.
        {

            Destroy(gameObject);
            Debug.Log("Damage item has collided with boundary. Destroy object.");
        }
    }



}


