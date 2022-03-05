﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongCountdownScript : MonoBehaviour
{

    public int countdownTime;
   // public Text countdownDisplay;
    [SerializeField] TextMeshProUGUI countdownDisplay;
    // Start is called before the first frame update

    /*
    private void Start()
    {
        StartCoroutine(CountdownToStart());
    } */

    public void SongCountdown()
    {
        StartCoroutine(CountdownToStart());
    }


    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }


        countdownDisplay.text = "GO!";

        countdownDisplay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}