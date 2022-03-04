using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMoverScript : MonoBehaviour
{

    public GameObject BombExplo;
    public GameObject Bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is the script that will make a bomb object explode after a few seconds.
        //Object should have some indicator it will go off (animation, flashing color)
        //Need to change tag so only the explosion it spawns will hurt the player, not the bomb itself. 
        //Erase collision on bomb prefab?
        //After two seconds spawn a bomb explosion effect
    }


    public void BombGone()
    {

        Destroy(Bomb);
        Destroy(BombExplo);
    }
}
