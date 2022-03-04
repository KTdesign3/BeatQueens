using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{


    public float beatTempo;

    public bool hasStarted;
    // Use this for initialization
    void Start()
    {
        beatTempo = beatTempo / 20f; //This will give you how fast the arrows should move per second.
        //hasStarted = false;
        //LaunchArrows();
    }

    //The void Countdown is new code that doesn't currently effect the script
    //I plan to use it to launch the void update
    public void LaunchArrows()
    {
        hasStarted = true;
    }



    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {

            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }

    }
}
