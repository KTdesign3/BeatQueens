using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainRaiseScript : MonoBehaviour
{
    public GameObject curtainGO;
    public bool curtainPull;
    public Transform CurtainUpPOS;
    public Transform CurtainDownPOS;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        curtainPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (curtainPull == true)
        {
            speed = 4;
        }
        if (curtainPull == false)
        {
            speed = 0;
        }

    }


    public void CurtainRaise()
    {
        //If this is called raise the curtain and keep it held up.
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        curtainPull = true;
        if (transform.position.y >= 11f)
        {
            speed = 0;
            curtainPull = false;
        }
        //If the curtain is at a y position of 4.0 stop it from moving.
    }

    public void CurtainLower()
    {
      
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        curtainPull = true;
        //transform.Translate(1, -2.9f, 31);
        //If dance mode is active lower the curtain and keep it lowered.

        if (transform.position.y <= -4f)
        {
            speed = 0;
            curtainPull = false;
        }
        //If the curtain is at a y position of -2.9 stop it from moving.
        
    }


    public void PositionCurtain() ///Repositions the curtain if you restart the level.
    {
        transform.position = new Vector3(6.7f, -4.12f, 30.9f);
    }
        
}
