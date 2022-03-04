using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{

    public Transform Target;
    public Transform myTransform;
   // public float ExpTimeLeft = 0; //Value is set in inspector
    // Start is called before the first frame update
    void Start()
    {
        //ExpTimeLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
        transform.Translate(Vector3.forward * 8 * Time.deltaTime);

        /*
        ExpTimeLeft -= Time.deltaTime;

        if (ExpTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
        {

            //Destroy(gameObject);
            // Debug.Log("Timer ran out bullet self destructed");
        } */
    }


    /*

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Ground") //This tag is on damage items. When the player collides with a damage item they will lose score.
        {

            Destroy(gameObject);
            Debug.Log("Bullet has collided with ground. Destroy Bullet.");
        } 

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground") //This tag is on damage items. When the player collides with a damage item they will lose score.
        {

            //  Destroy(gameObject);
            // Debug.Log("Follower has collided with player. Destroy Bullet.");
        }



    } */
}
