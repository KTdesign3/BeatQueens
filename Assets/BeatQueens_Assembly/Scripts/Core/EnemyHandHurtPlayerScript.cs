using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandHurtPlayerScript : MonoBehaviour
{


    public GameObject PlayerDamage;
    public GameObject Navi;
    //public GameObject Navi;
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
            //Deduct 50 points from the player score.
            Debug.Log("Hand hit the player in EnemyHandHurtPlayerScript, deducting points from player script");
            PlayerDamage.GetComponent<PlayerScore>().HarmPlayer();


        }

    }
}
