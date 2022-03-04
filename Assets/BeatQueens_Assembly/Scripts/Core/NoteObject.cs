using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {


	public bool canBePressed;

	public KeyCode keyToPress;
	//public class Script ScoreScript;
	

	// Use this for initialization
	void Start () 
	{
		
	} /*
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(keyToPress))
        {
			if(canBePressed)
            {
				gameObject.SetActive(false); //Destroys arrow if the player hits the key while the arrow has canBePressed enabled.
			    ScoreScript.scoreValue += 10; //Adds 10 points to player score
				
				//ScoreManager.GetComponent<ScoreScript>(scoreValue);

			}
        }
	}


	private void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Activator") //This tag is on the arrow boxes. When the arrow collides with the arrow box it enables can be pressed,
        {
			canBePressed = true;
			EnemyScoreScript.EnemyScoreValue += 5; // Adds 5 points to enemy score when arrows collide with the box
		}

		if (other.tag == "LosePointBox") //This tag is on the arrow boxes. When the arrow collides with the arrow box it enables can be pressed,
		{
			canBePressed = false;
			ScoreScript.scoreValue -= 5;
			Debug.Log("Arrow has been missed, -5 points");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Activator")
		{
			canBePressed = false;
		}
	} */

	//// How To Make a Rhythm Game #1 - Hitting Notes https://www.youtube.com/watch?v=cZzf1FQQFA0
}
