using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerColorScript : MonoBehaviour





{

    [SerializeField] private Material injuryMat;
    public Material[] NaviplayerMat;
    Renderer rend;

    public float InjuryTimeLeft = 0.001f; //Value is set in inspector. 
    public bool InjuryTimerActive;
    public bool InjuryMade;
    public GameObject Player;
    public int x;
    public SkinnedMeshRenderer NaviBodyGO;

    public Material playerMat;
    
    //public Material SpriteDefaultMat;


    // Start is called before the first frame update
    void Start()
    {
        // BulletTimeLeft = 5;
        //playerMat.color = Color.blue;
        InjuryTimeLeft = 0.001f;
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = NaviplayerMat[x];


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
            //injuryMat.color = Color.white; //Changes material to white if player dashes into enemy.
           playerMat.color = Color.red; //Changes material to white if player dashes into enemy.
            Debug.Log("Player has been hurt, running flashing white code now in HurtPlayerColorScript");
            x = 1;
            yield return new WaitForSeconds(0.5f);
            //InjuryMade = false; //Resets injury timer after flashing
            InjuryTimeLeft = 0.001f;
            //  playerMat.color = Color.blue;
            x = 0;
        }


    }

    // Update is called once per frame



    void Update()
    {

        rend.sharedMaterial = NaviplayerMat[x];


        if (Input.GetKey(KeyCode.L))
        {
            //injuryMat.color = Color.white;
            Debug.Log("Player has been hurt. Calling Injury flash coroutine.");
            StartCoroutine(InjuryFlash());
        }

    }


    public void NextColor()
    {
        if (x<2)
        {
            x++;
        }
        else
        {
            x=0;
        }
    }

}

