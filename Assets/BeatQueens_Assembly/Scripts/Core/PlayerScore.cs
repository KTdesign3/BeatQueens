using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public bool PlayerVulnerable;
    public GameObject PlayerDamageObject;
    // Start is called before the first frame update
    void Start()
    {
        PlayerVulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage") //This tag is on the arrow boxes. When the arrow collides with the arrow box it enables can be pressed,
        {
            
            ScoreScript.health -= 5;
            Debug.Log("Player has collided with a damage item!");

            //Added by KS 14/01/2022
            //When the player is hurt the cube will flash white. This will be applied to the 3D model for Navi.
            PlayerDamageObject.GetComponent<HurtPlayerColorScript>().Injury();
            Debug.Log("Player hurt flash play");
            //ScoreManager.comboScore - 5;
            // ScoreM.GetComponent<ScoreManager>().Hit();
            //ScoreManager.comboScore -= 5;
        }

        //Note: This code should only trigger once the enemy is in attack mode. otherwise it shouldn't trigger. The enemy hand script sets this code.
        /*
        if (other.tag == "EnemyHandHurtPlayer" && PlayerVulnerable == true)
        {
            ScoreScript.health -= 50;
            Debug.Log("Player has been hit by enemy hand! EnemyHandHurtPlayer is working in PlayerScore Script!");
        } */
    }


    public void HarmPlayer()
    {
        PlayerVulnerable = true;
        ScoreScript.health -= 50;
        //Debug.Log("Player has been hit by enemy hand via HarmPlayer function!!");

        //Added by KS 14/01/2022
        //When the player is hurt the cube will flash white. This will be applied to the 3D model for Navi.
        PlayerDamageObject.GetComponent<HurtPlayerColorScript>().Injury();
        Debug.Log("Player hurt flash play");
    }


    public void ProtectPlayer()
    {
        PlayerVulnerable = false;
    }

    /*

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage") //This tag is on damage items. When the player collides with a damage item they will lose score.
        {

            ScoreScript.scoreValue -= 5;
            Debug.Log("Player has collided with a damage item!");
        }


    } */
}
