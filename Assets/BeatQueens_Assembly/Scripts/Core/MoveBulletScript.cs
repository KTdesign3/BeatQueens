using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletScript : MonoBehaviour
{

    public float BulletTimeLeft = 3; //Value is set in inspector. Value for time pellets have left.
    public bool BulletTimerActive;
    public bool BulletMade;
    public GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        BulletTimeLeft = 5;
        //  PelletSpawnerActive = true;
       // BulletMade = true;

    }

    public void BulletsStart()
    {
        BulletMade = true;
       

    }

    public void BulletsStop()
    {
        BulletMade = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (BulletTimeLeft >= 3) //If the bulletTimeLeft is greater than or equal to 3 its speeds will be 0. if its less than 3. This allows the bullet to pause for a few seconds before falling down.

        {
            transform.Translate(Vector3.down * 0 * Time.deltaTime);
        }

        if (BulletTimeLeft < 3) //If the bulletTimeLeft is less than 3 its speeds will be 5

        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }

        //transform.Translate(Vector3.down * 5 * Time.deltaTime);
        Debug.Log("Calling bullet movement");
       // BulletMade = true;

       
            BulletTimerActive = true;
            BulletTimeLeft -= Time.deltaTime;
            if (BulletTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
            {
                Destroy(Bullet);
                //  Destroy(Bomb);
                Debug.Log("DESTROY PELLET");
                BulletMade = false;
                BulletTimeLeft = 3;
            }
        
    }

    void OnCollisionEnter(Collision collision)
    {

    

        if (collision.gameObject.tag == "Player") //This is the tag gives to bars that go along the edges of the game screen. They cannot be seen but help 'catch' stray projectiles.
        {

            Destroy(gameObject);
            Debug.Log("Bullet has collided with player. Destroy Bullet.");
        }
    }
}
