using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //New code I added
using TMPro;

public class ScoreManager : MonoBehaviour
{
    /*
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    // public TMPro.TextMeshPro scoreText;
    public TextMeshProUGUI scoreText;
    public static int comboScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }
    public static void Hit()
    {
        comboScore += 2;
        Instance.hitSFX.Play();
        Debug.Log("Player hit a note");
    }
    public static void Miss()
    {
        comboScore -= 4;
        Instance.missSFX.Play();
        Debug.Log("Player missed a note");
    }
    /*
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
    
    public void Update()
    {
        scoreText.text = "PlayerScore" + comboScore.ToString(); //This adds on
       
    } */
}
