using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainRaiseScript : MonoBehaviour
{
    public GameObject curtainGO;
    public bool curtainPull;
    public Transform CurtainUpPOS;
    public Transform CurtainDownPOS;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        curtainPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CurtainRaise()
    {
        speed = 4;


        //If this is called raise the curtain and keep it held up.
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= 17.23f)
        {
            speed = 0;
        }
        //If the curtain is at a y position of 4.0 stop it from moving.
    }

    public void CurtainLower()
    {
        speed = 4;
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        transform.Translate(1, -2.9f, 31);
        //If dance mode is active lower the curtain and keep it lowered.

        if (transform.position.y >= -2.9f)
        {
            speed = 0;
        }
        //If the curtain is at a y position of -2.9 stop it from moving.
        
    }
}
