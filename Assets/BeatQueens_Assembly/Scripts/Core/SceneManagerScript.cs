using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    bool PauseActive;
    bool PauseInactive;
    public GameObject SongM;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    public void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            {
                Application.Quit(); //Quits the game if you hit the escape key.
            }

        } */


        /*

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            {
                PauseGame();
                PauseActive = true;
                SongM.GetComponent<SongManager>().StopSong(); //THIS CODE PAUSES THE SONG!
            }
           
        }


     



    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        PauseActive = true;
        PauseInactive = false;
        //Disable scripts that still work while timescale is set to 0
        SongM.GetComponent<SongManager>().StopSong(); //THIS CODE PAUSES THE SONG!

    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        PauseActive = false;
        PauseInactive = true;
        //enable the scripts again
        SongM.GetComponent<SongManager>().ResumeSong();
    }

    public void QuitGame()
    {

        Application.Quit();
        Debug.Log("Player has quit game"); */
    }
}



