using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dypsloom.Shared;
using Dypsloom.RhythmTimeline.Core.Managers;

public class TestScript : MonoBehaviour
{
    private Dypsloom.RhythmTimeline.Scoring.ScoreManager m_dypsloomSM;
    private RhythmDirector m_rhythmDirector;
    private RhythmProcessor m_rhythmProcessor;


    // Start is called before the first frame update
    void Start()
    {
        m_dypsloomSM = Toolbox.Get<Dypsloom.RhythmTimeline.Scoring.ScoreManager>();
        m_rhythmDirector = Toolbox.Get<RhythmDirector>();
        m_rhythmProcessor = Toolbox.Get<RhythmProcessor>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestMessage(string message)
    {
        Debug.Log(message);

        float currentScore = m_dypsloomSM.GetScore();
        Debug.Log("Current score is " + currentScore);
    }
}
