using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportScript : MonoBehaviour
{

    public GameObject Navi;
    public Transform PlayerDancePos;
    public GameObject TeleporterGO;
    public bool TeleporterFXOn;
    public GameObject TeleportFXGO;
    // Start is called before the first frame update
    void Start()
    {
        TeleporterGO.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


      

        /*
        if (Input.GetKey(KeyCode.G) == true)
        {

           //This line of code teleports the player back to the dance pad
            transform.position = new Vector3(0, -2.41f, -1.4f);
            //The below line of code freezes the player in position
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            //PlayerSpeed = 0;
            Debug.Log("Reset position");
        } */




    }


    public void TeleportPlayer()
    {

        transform.position = new Vector3(0, -2.41f, -1.4f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        SoundManager.inst.PlaySound("TeleportFX");
       // TeleporterGO.SetActive(true);
        //TeleporterFXOn = true;
        TeleportFXGO.GetComponent<TeleporterControllerScript>().EnableTeleporter(); //Calls teleporter FX

    }

    /*
    public void weeblewobble()
    {
        if (TeleporterFXOn == true)
        {
            yield return new WaitForSeconds(0.3f);
            TeleporterGO.SetActive(false);
        }
    }
     */


  

    //Code to resets players position if they end up out of bounds
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HandContainer")
        {
            TeleportPlayer();
            Debug.Log("Somehow player got out of bounds. Teleported back to dance pad.");

        }
    }




}
