using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//New lines added by KS 13/01/2022
using Dypsloom.Shared;

public class GameWinScript : MonoBehaviour
{

    public GameObject PlayerScore; //scorevalue
    public GameObject QueensScore;
    public GameObject PlayerScoreContainer;   //This is on the gameobject scoreText of TimeCanvas.
    public GameObject RedQueenScoreContainer; //This is on the gameobject enemy score test.
    public GameObject WinCanvas;
    public GameObject PlayerWinText;
    public GameObject EnemyWinText;
    public int scoreValue;
   

    //These are ints I made for this script. These two ints work as a label that will reference the EnemyScoreValue and health ints in the other scripts.
    //You can see these references in the void update for this script.
    public static int EnemyScoreHealthRef;
    public static int PlayerHealthRef;

    //New lines added by KS 13/01/2022
    public static int DypScoreRef;


    //New lines added by KS 13/01/2022
    private Dypsloom.RhythmTimeline.Scoring.ScoreManager m_dypsloomSM;


    // Start is called before the first frame update
    void Start()
    {
        //New lines added by KS 13/01/2022
        m_dypsloomSM = Toolbox.Get<Dypsloom.RhythmTimeline.Scoring.ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //New lines added by KS 13/01/2022
        float dypsloomScore = m_dypsloomSM.GetScore();

        //New lines added by KS 13/01/2022

        EnemyScoreHealthRef = EnemyScoreScript.EnemyScoreValue;
        PlayerHealthRef = ScoreScript.health;

        //Line added by KS 18/01/2022
        //Reccomended by John.
        DypScoreRef = (int)m_dypsloomSM.GetScore();
        // DypScoreRef = m_dypsloomSM.GetScore;

        //DypScoreRef = ScoreScript.GetScore;
    }


    public void CheckAllScores() //This code is called by the countdown script and checks the play and the queens scores once the timer hits 0.
    {
        GetComponent<EnemyScoreScript>();
        GetComponent<PlayerScore>();
        
        if (PlayerHealthRef + DypScoreRef > EnemyScoreHealthRef) //If the players score is more than the queens score display this message
        {
            Debug.Log("You won!");
            PlayerWinText.SetActive(true);
            
        }

        if (PlayerHealthRef + DypScoreRef < EnemyScoreHealthRef) //If the players score is more than the queens score display this message
        {
          

            Debug.Log("You lost!");
            EnemyWinText.SetActive(true);

        }

       

    }

    //KS
    //Added 13/01/2022
    //This function ClearScoreText will clear the enemy and players score back to 0 when the song starts.
    public void ClearScoreText()
    {
        EnemyWinText.SetActive(false);
        PlayerWinText.SetActive(false);
    }



}
