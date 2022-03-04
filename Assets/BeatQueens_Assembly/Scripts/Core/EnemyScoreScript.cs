using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScoreScript : MonoBehaviour
{

    /// <summary>
    /// This script controls the enemy score. It inherits from the BeatScroller script which adds 5 points to the enemies score when an arrow
    /// collides with an arrow box
    /// </summary>

    public static int EnemyScoreValue = 0;
    Text Enemyscore;

    // Use this for initialization
    void Start()
    {
        Enemyscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemyscore.text = "Enemy Score: " + EnemyScoreValue;
    }

    //ScoreScript.scoreValue -= 5;
    //EnemyScoreScript.EnemyScoreValue += 5;


    public void LowerQueenScore()
    {
        EnemyScoreValue = 0;
    }
}
