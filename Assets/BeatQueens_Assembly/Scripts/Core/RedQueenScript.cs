using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedQueenScript : MonoBehaviour
{
    public Animator QueenAnim;
    public bool DanceTrue;


    public bool DanceScoreUp;
    public bool DanceScoreDown;
    //WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    public float ScoreTimer = 0;
    public GameObject EnemyHandGO;


    // Start is called before the first frame update
    void Start()
    {
        DanceTrue = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DanceTrue == true)
        {
            QueenDance();
            DanceScoreUp = true;
        }

        if (DanceTrue == false)
        {
            QueenIdle();
            DanceScoreUp = false;
        }

        if (DanceScoreUp == true) //This code
        {
            //AttackTimer = true;
            ScoreTimer += Time.deltaTime;
            if (ScoreTimer >= 2) //This will add 5 to
            {
                EnemyScoreScript.EnemyScoreValue += 1000;
                Debug.Log("Time left");
                ScoreTimer = 0;
            }
        }

        if (DanceScoreDown == true)
        {
            EnemyScoreScript.EnemyScoreValue -= 500;
        }



    }

    
    public void DanceStart()
    {
        DanceTrue = true;
        QueenDance();
        Debug.Log("DanceStart has been called");
    }

    public void DanceStop()
    {
        DanceTrue = false;
        QueenIdle();

        Debug.Log("DanceStop has been called");
    }

    public void QueenStopAll()
    {
        QueenAnim.SetBool("RedQueenDance", false);
        QueenAnim.SetBool("RedQueenIdle", true);
        QueenIdle();


    }

    public void QueenDance()
    {
        QueenAnim.SetBool("RedQueenDance", true);
        QueenAnim.SetBool("RedQueenIdle", false);
        DanceScoreUp = true;

        
    }

    public void QueenIdle()
    {
        QueenAnim.SetBool("RedQueenDance", false);
        QueenAnim.SetBool("RedQueenIdle", true);
        DanceScoreUp = false;
    }

   public void QueenScoreDown()
    {
        EnemyScoreScript.EnemyScoreValue -= 500;
    }

    public void QueenHandInjured()
    {
        EnemyScoreScript.EnemyScoreValue -= 500;
        EnemyHandGO.GetComponent<HurtColorChangeScript>().Injury();// Calls code that makes queens hand flash
    }

    public void RedQueenScoreReset()
    {
        EnemyScoreScript.EnemyScoreValue = 0;
    }

    //EnemyScoreScript.EnemyScoreValue += 5;
    /*
    public void EnemyScoreReset()
    {
        EnemyScoreScript
    } */

}
