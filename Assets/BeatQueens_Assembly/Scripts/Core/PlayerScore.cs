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
            SoundManager.inst.PlaySound("NaviTakeDamage");

            //Added by KS 14/01/2022
            //When the player is hurt the cube will flash white. This will be applied to the 3D model for Navi.


            //Commented out by KS 25/03/2022
            //Commenting this out to fix bug.
            //PlayerDamageObject.GetComponent<HurtPlayerColorScript>().Injury();
            // Debug.Log("Player hurt flash play");

        }

        
    }


    public void HarmPlayer()
    {
        PlayerVulnerable = true;
        ScoreScript.health -= 50;

        PlayerDamageObject.GetComponent<HurtPlayerColorScript>().Injury();
        Debug.Log("Player hurt flash play"); 
        //SoundManager.inst.PlaySound("NaviTakeDamage");
    }


    public void ProtectPlayer()
    {
        PlayerVulnerable = false;
    }

   

}
