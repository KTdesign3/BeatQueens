using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandHurtHandScript : MonoBehaviour
{

    public GameObject PlayerDamage;
    public GameObject Navi;
    public GameObject EnemyHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.tag == "PlayerDamage")
        {

            Debug.Log("Player dashed into EnemyHandHurtHandScript, deducting points from enemy hand");
            
            //Deduct 50 points from the enemy score.
            //EnemyScoreScript.EnemyScoreValue -= 50;
            //HurtColorChangeScript.Injury();

            //Added by KS 14/01/2022
            //Makes enemy hand flash when injured
            EnemyHand.GetComponent<HurtColorChangeScript>().Injury();



        }

    }
}
