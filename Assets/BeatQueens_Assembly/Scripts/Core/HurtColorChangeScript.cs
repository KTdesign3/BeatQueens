using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtColorChangeScript : MonoBehaviour
{

    [SerializeField] private Material injuryMat;
    public Material handMat;

    public float InjuryTimeLeft = 0.001f; //Value is set in inspector. 
    public bool InjuryTimerActive;
    public bool InjuryMade;
    public GameObject EnemyHeart;
    //public Material HeartMat;
    //public Material InjuryMat;
    public Material[] materials;
    public int index = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        // BulletTimeLeft = 5;
       // handMat.color = Color.red;
        InjuryTimeLeft = 0.001f;


        //EnemyHeart.GetComponent<MeshRenderer>().material.color = Color.red
        //renderer.material = materials[index];
        GetComponent<Renderer>();


    }


   
    public void Injury()
    {
        StartCoroutine(InjuryFlash());
        InjuryTimerActive = true;
        // StartCoroutine(Timer1());
    }

    private IEnumerator InjuryFlash()
    {
       
        InjuryTimeLeft -= Time.deltaTime;
        if (InjuryTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
        {
            InjuryTimerActive = true;
            InjuryMade = true;
            //injuryMat.color = Color.white; //Changes material to white if player dashes into enemy.
            //handMat.color = Color.white; //Changes material to white if player dashes into enemy.
            index = 0;
            // renderer.material = materials[1];
            //GetComponent<Renderer>(1);
            //GetComponent<Renderer>(1);
            Debug.Log("Player has injured enemy, running flashing white code now");
            yield return new WaitForSeconds(0.1f);
            //InjuryMade = false; //Resets injury timer after flashing
            InjuryTimeLeft = 0.001f;
            //handMat.color = Color.red;
            
        }

        if (InjuryTimeLeft > 0) //This sets the color back to the 1 in the material slot.
        {
           
            index = 1;
            

        }

        /*
        timer1 = startTime;

        do
        {
            timer1 -= Time.deltaTime;
            slider1.value = 1 - timer1 / startTime; //The -1 makes the slider go forwards as opposed to backwards

            FormatText1();
            yield return null;
        }
        while (timer1 > 0); */
    }

    // Update is called once per frame


    
    void Update()
    {


        if (Input.GetKey(KeyCode.L))
        {
            //injuryMat.color = Color.white;
            Debug.Log("Calling Injury flash coroutine.");
            StartCoroutine(InjuryFlash());
        }
        /*

        if (Input.GetKeyDown(KeyCode.L))
        {
            injuryMat.color = Color.white;
            Debug.Log("Calling injure hand code.");
            StartCoroutine(InjuryFlash());
        }


        if (InjuryTimeLeft >= 1) //If the bulletTimeLeft is greater than or equal to 3 its speeds will be 0. if its less than 3. This allows the bullet to pause for a few seconds before falling down.

        {
            //transform.Translate(Vector3.down * 0 * Time.deltaTime);
            
            EnemyHand.GetComponent<Renderer>().material = handMat;

        }

        if (InjuryTimeLeft < 0.6f) //If the bulletTimeLeft is less than 3 its speeds will be 5

        {
            //transform.Translate(Vector3.down * 5 * Time.deltaTime);
            injuryMat.color = Color.white; //Changes material to white if player dashes into enemy.
        }

        //transform.Translate(Vector3.down * 5 * Time.deltaTime);
        Debug.Log("Calling bullet movement");
        // BulletMade = true;
        

        InjuryTimerActive = true;
        InjuryTimeLeft -= Time.deltaTime;
        if (InjuryTimeLeft <= 0) //This will explode the object after ExpTimeLeft hits 0.
        {
            
            injuryMat.color = Color.white; //Changes material to white if player dashes into enemy.
            Debug.Log("Player has injured enemy, running flashing white code now");
            // InjuryMade = false; //Resets injury timer after flashing
            // InjuryTimeLeft = 3;
            yield return new WaitForSeconds(1.5f);
        } */

    }


}
