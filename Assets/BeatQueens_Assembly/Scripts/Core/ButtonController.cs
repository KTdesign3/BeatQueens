using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	private SpriteRenderer theSR;
	public Sprite defaultImage;
	public Sprite pressedImage;


	public KeyCode keyToPress;

	// Use this for initialization
	void Start () 
	{
		theSR = GetComponent<SpriteRenderer>();
	}


	/*If the arrow collides with this button and the player doesn't hit the corresponding key,
	 * they lose 10 points. If they hit the key they gain 10 points. If their score goes to 0,
	 they lose the game.*/
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(keyToPress))
        {
			theSR.sprite = pressedImage;
        }


		if(Input.GetKeyUp(keyToPress))
        {
			theSR.sprite = defaultImage;
        }
	}
}
