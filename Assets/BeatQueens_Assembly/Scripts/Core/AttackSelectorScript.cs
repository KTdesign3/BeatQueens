using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelectorScript : MonoBehaviour
{

    public float AttackTimer = 1; //Time until random AI choice is selected. It will select a different case every (insert time of attack timer float).
    public Rigidbody DamageSphere;
    
    // https://answers.unity.com/questions/1279143/random-selection-1.html


  /*

    IEnumerator Start()
    {
        for ( )
        {
            int x = Random.Range(0, 3);
            switch (x)
            {
                case 0:
               
                    Debug.Log("Case 0");
                    Rigidbody clone;
                    clone = Instantiate(DamageSphere, transform.position, transform.rotation);

                    clone.velocity = transform.TransformDirection(Vector3.forward * 10);

                    break;
                case 1:
                    Debug.Log("Case 1");


                    break;
                case 2:
                    Debug.Log("Case 2");


                    break;
            }
            yield return new WaitForSeconds(AttackTimer);
        }
    }
  */

   

}
