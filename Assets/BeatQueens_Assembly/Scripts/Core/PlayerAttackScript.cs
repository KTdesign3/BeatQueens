using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

	public GameObject AttackRange;
	public bool CanAttack;
	public bool IsAttacking;
	public GameObject EnemyHandGO;
	public GameObject RedQueenGO;
    // Start is called before the first frame update
    void Start()
    {
		CanAttack = false;
		IsAttacking = false;
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			CanAttack = true;



		}

	}

	void OnCollisionExit(Collision collision) //Sets onFloor to off when you jump. Movement is resricted
	{
		if (collision.gameObject.tag == "Enemy")
		{
			CanAttack = false;

		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			CanAttack = true;



		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			CanAttack = false;



		}

	}


	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonDown(0)) //0 for left mouse button, 1 for right mouse button
		{
			print("Character attacking");
			IsAttacking = true;
			
		}


	    if (Input.GetKeyDown(KeyCode.RightShift) == true) //This is the right dash attack
        {
			IsAttacking = true;
		}

		else
        {
			IsAttacking = false;
        }


		if (CanAttack == true && IsAttacking == true)
		{

			//EnemyScoreScript.EnemyScoreValue -= 5;
			//RedQueenGO.GetComponent<RedQueenScript>().QueenHandInjured();
			Debug.Log("Hit Enemy, launching hurt color change script on enemy hand"); //This code will knock down the enemies score when you collide with an object tagged enemy and hit it.
			//EnemyHandGO.GetComponent<HurtColorChangeScript>().Injury();// Calls code that makes queens hand flash

			/* If the player is colliding with an enemy item and hits the left mouse button it will take 5 off of the enemies score */



		}



	}



}
