using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterControllerScript : MonoBehaviour
{

    public GameObject TeleporterFXGO;
    public GameObject TeleporterShimmerGO;
    public bool TeleporterFXOn;
    public float TeleporterTimeLeft = 0.5f; //Value is set in inspector. Value for time pellets have left.
    public bool TeleporterTimerActive;
    // Start is called before the first frame update
    void Start()
    {
        TeleporterTimeLeft = 0.5f; ///Teleport timer is set to 0 by defaults
        TeleporterFXGO.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   


    
    public void EnableTeleporter() //If the teleporter enabler is called the teleporter is set to active and its time is set to 0.5. 
    {

        TeleporterShimmerGO.SetActive(true);
       // TeleporterTimeLeft = 0.5f;
        StartCoroutine(EnableTeleporterTimer()); //This calls the coroutine that will disable the teleporter fx after a set period of time.
        TeleporterTimerActive = true;
    }


    public void DisableTeleporter()
    {
        /* if (TeleporterFXOn == true)
         {
             yield return new WaitForSeconds(0.3f);
             TeleporterGO.SetActive(false);
         } */

        TeleporterShimmerGO.SetActive(false);
        TeleporterTimerActive = false;
        TeleporterFXOn = false;
    }


    private IEnumerator EnableTeleporterTimer()
    {
        TeleporterTimerActive = true;
        TeleporterTimeLeft -= Time.deltaTime;
        
        if (TeleporterTimeLeft <= 0.01f) //This will explode the object after ExpTimeLeft hits 0.
        {
           
            //TeleporterFXOn = false;
           // TeleporterTimeLeft = 0.0f;
            DisableTeleporter();
            Debug.Log("Turning off teleporter FX now");
            TeleporterFXOn = false;
            yield return new WaitForSeconds(0.5f);

        }

        if (TeleporterTimeLeft > 0.1f) //This sets the color back to the 1 in the material slot.
        {

            TeleporterFXOn = true;
            //Debug.Log("Turning off teleporter FX now");
            Debug.Log("Running teleporter FX code now");

        }

        
    }




}
