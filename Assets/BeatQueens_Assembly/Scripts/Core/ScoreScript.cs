using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dypsloom.Shared;

public class ScoreScript : MonoBehaviour {

	public static int health = 0;
	//public static int scoreValue = 0;
	Text score;
	private Dypsloom.RhythmTimeline.Scoring.ScoreManager m_dypsloomSM;


	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
		m_dypsloomSM = Toolbox.Get<Dypsloom.RhythmTimeline.Scoring.ScoreManager>();

	}

	// Update is called once per frame
	void Update () {
		float dypsloomScore = m_dypsloomSM.GetScore();
		score.text = "Player Score: " + (dypsloomScore + health);
		Debug.Log("Getting player health and score");
	}

	public void ResetPlayerScore()
    {
		health = 0;

	}
}
