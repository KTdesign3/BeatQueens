using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{


    public float PelletBigTimeLeft = 3;
    public bool PelletBigTimerActive;
    public bool PelletBigTimerMade;
    //public GameObject Pellet;
    GameObject ProjectilePrefab;



    // Start is called before the first frame update
    void Start()
    {
       PelletBigTimeLeft = 3;
    }

    public void BigPelletStart()
    {
        PelletBigTimerMade = true;
        ProjectilePrefab = Instantiate(ProjectilePrefab);

    }

    public void BigPelletStop()
    {
        PelletBigTimerMade = false;


    }

    void Update()
    {
       // transform.Translate(Vector3.down * 5 * Time.deltaTime);
        Debug.Log("Calling bullet movement");
        // BulletMade = true;


        PelletBigTimerActive = true;
        PelletBigTimeLeft -= Time.deltaTime;
        if (PelletBigTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
        {

            //Destroy(Pellet);

            //  Destroy(Bomb);
            //Destroy(PelletInstantiated);
            Destroy(ProjectilePrefab, 2.0f);
            Debug.Log("DESTROY PELLET");
            PelletBigTimerMade = false;
            PelletBigTimeLeft = 3;
        }

    }
}
