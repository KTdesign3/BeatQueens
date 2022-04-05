using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] float startTime = 5f;
    [SerializeField] Slider slider1;
    //[SerializeField] Slider slider2;
    [SerializeField] TextMeshProUGUI timerText1;
    //[SerializeField] TextMeshProUGUI timerText2;
    public float timer1 = 195f;
    public GameObject EnemyHeart;
    public GameObject AttackSpawnerGO;
    public GameObject Navi;
    public GameObject PlayerTeleportGO;
    public GameObject CombatText;
    public GameObject DanceText;
    public GameObject EndText;
    public GameObject Bullet;
    public GameObject Pellet;
    public GameObject SectionCanvasGO;
    public GameObject SongCountdownTimerGO;
    public GameObject RedQueenGO;
    public GameObject EnemyHandGO;
    public GameObject PlayerScoreGO;
    public GameObject TracksGO;
    public GameObject curtainGO; //This is the curtain game object that separates the queen and Navi.
    [SerializeField] GameObject EnemyScoreTest;
    public float Dance1 = 196f;
    public float Combat1 = 132f;
    public float Dance2 = 100f;
    public float Combat2 = 52f;

    //Calls on score objects
    public GameObject ScoreCounterGO;

    public static CountdownScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // JHCommented this out as I am not sure you 
        // want it now that I have added back the StartEverything
        // function
        // StartEverything();
    }

    public void StartEverything()
    {
        StartCoroutine(Timer1());
        Debug.Log("Start everything has been called");

        //Calls countdown code from song countdown script.
        // SongCountdownTimerGO.GetComponent<SongCountdownScript>().SongCountdown(); 


        //Added by KS 13/01/2022
        //Hides 'song finished!' text when you start a new song.
        EndText.SetActive(false);
        TracksGO.SetActive(true);
        ResetScore();
    }


    public void StopEverything()
    {
        //StopCoroutine(Timer1());
        
    }

    public void ResetScore()
    {
        //LowerQueenScore
        EnemyScoreTest.GetComponent<EnemyScoreScript>().LowerQueenScore();
        PlayerScoreGO.GetComponent<ScoreScript>().ResetPlayerScore();

    }


    public void GameHasEnded()
    {
        EnemyHeart.SetActive(false); //Spawns enemy hand on EnemyHandGO;
        AttackSpawnerGO.SetActive(false); //Spawns enemy attacks in AttackSpawnerScript
        Navi.GetComponent<PlayerMovement>().DanceActive(); //Controls player being frozen or not
        PlayerTeleportGO.GetComponent<PlayerTeleportScript>().TeleportPlayer(); //Calls on PlayerTeleportScript to teleport the player
        CombatText.SetActive(false);
        EndText.SetActive(true);
        TracksGO.SetActive(false);
        Bullet.GetComponent<MoveBulletScript>().BulletsStop();
        Pellet.GetComponent<RadialAttackScript>().PelletStop();
        Navi.GetComponent<PlayerMovement>().LockPlayer();
        AttackSpawnerGO.GetComponent<AttackSpawnerScript>().SpawnAllowCallStop();
        RedQueenGO.GetComponent<RedQueenScript>().QueenStopAll(); //Stops queens score and dancing
    }

    #region Timer

    private IEnumerator Timer1()
    {
        timer1 = startTime;

        do
        {
            timer1 -= Time.deltaTime;
            slider1.value = 1 - timer1 / startTime; //The -1 makes the slider go forwards as opposed to backwards

            FormatText1();
            yield return null;
        }
        while (timer1 > 0);
    }


    private void FormatText1()
    {
        //int hours = (int)(timer1 / 3600) % 24; // This calulates how many seconds are in an hour
        int minutes = (int)(timer1 / 60) % 60; // This calulates how many seconds are in a minute
        int seconds = (int)(timer1 / 1) % 60; //This tells the game how many seconds are in a minute

        timerText1.text = ""; //Sets timer text to nothing so formatting looks nice


        if (minutes > 0) { timerText1.text += minutes + ":"; } //Displays : symbol beside minutes.
        if (minutes < 1) { timerText1.text += "0:"; } //Displays : symbol beside minutes.
                                                      // if (seconds < 1) { timerText1.text += "" + seconds; } //Displays seconds
        if (seconds < 10) { timerText1.text += "0" + seconds; } //Displays seconds
        if (seconds > 10) { timerText1.text += "" + seconds; } //Displays seconds
        if (seconds == 10) { timerText1.text += "" + seconds; } //Displays seconds
                                                                //   if (seconds > 61) { timerText1.text += "0:" + seconds; } //Displays seconds



    }


    public void Update()
    {
        if (timer1 <= 0)
        {
            //Calls ScoreManagerGO to check player and queens scores
            //Checks whether player or queen has more points
            ScoreCounterGO.GetComponent<GameWinScript>().CheckAllScores();
            

            

            //Code added by KS
            //Added 12/01/2022
            GameHasEnded();

            Debug.Log("GameHasEnded code being called in CountdownScript.");
        }

       
        // if (timer1 > 133)
        if (timer1 > 127 && timer1 <= 190) //If timer 1 isi greater than 133 and less than 196, do this. 
        {
            
            Debug.Log("Queens score is rising");
            //KS Added
            RedQueenGO.GetComponent<RedQueenScript>().DanceStart();
            //TracksGO.SetActive(true);


        }

        // if (timer1 > 133)
        if (timer1 > 133 && timer1 <= 196) //If timer 1 is greater than 133 and less than 196, do this.
        {
            DanceText.SetActive(true);
            Debug.Log("Dance 1 mode active ");
            TracksGO.SetActive(true);

        }

        if (timer1 > 100 && timer1 <= 126) //Set to 132 for beat drop
        {
            
            Debug.Log("Combat 1 mode active ");
            EnemyHeart.SetActive(true);
            AttackSpawnerGO.SetActive(true);
            Navi.GetComponent<PlayerMovement>().CombatActive();
            CombatText.SetActive(true);
            DanceText.SetActive(false);
            Bullet.GetComponent<MoveBulletScript>().BulletsStart();
            Pellet.GetComponent<RadialAttackScript>().PelletStart();
            Navi.GetComponent<PlayerMovement>().UnLockPlayer();
            AttackSpawnerGO.GetComponent<AttackSpawnerScript>().SpawnAllowCall();
            RedQueenGO.GetComponent<RedQueenScript>().DanceStop();
            TracksGO.SetActive(false);
            curtainGO.GetComponent<CurtainRaiseScript>().CurtainRaise(); //Raises curtain


        }



        if (timer1 > 51.5f && timer1 <= 100)
        {
            
            Debug.Log("Dance mode 2 active ");
            EnemyHeart.SetActive(false); //Spawns enemy hand on EnemyHandGO;
            AttackSpawnerGO.SetActive(false); //Spawns enemy attacks in AttackSpawnerScript
            Navi.GetComponent<PlayerMovement>().DanceActive(); //Controls player being frozen or not
            PlayerTeleportGO.GetComponent<PlayerTeleportScript>().TeleportPlayer(); //Calls on PlayerTeleportScript to teleport the player
            CombatText.SetActive(false);
            DanceText.SetActive(true);
            Bullet.GetComponent<MoveBulletScript>().BulletsStop();
            Pellet.GetComponent<RadialAttackScript>().PelletStop();
            Navi.GetComponent<PlayerMovement>().LockPlayer();
            AttackSpawnerGO.GetComponent<AttackSpawnerScript>().SpawnAllowCallStop();
            RedQueenGO.GetComponent<RedQueenScript>().DanceStart();
            TracksGO.SetActive(true);
            curtainGO.GetComponent<CurtainRaiseScript>().CurtainLower(); //Raises curtain

        }

        if (timer1 <= 95)
        {
            //EndText.SetActive(true);
        }


        if (timer1 > 0 && timer1 <= 42.5) //44.5
        {
            //ScoreCounterGO.GetComponent<GameWinScript>().CheckAllScores(); //Calls ob ScoreManagerGO to check player and queens scores
            Debug.Log("Combat mode 2 active");
            EnemyHeart.SetActive(true);
            AttackSpawnerGO.SetActive(true);
            Navi.GetComponent<PlayerMovement>().CombatActive();
            CombatText.SetActive(true);
            DanceText.SetActive(false);
            Bullet.GetComponent<MoveBulletScript>().BulletsStart();
            Pellet.GetComponent<RadialAttackScript>().PelletStart();
            Navi.GetComponent<PlayerMovement>().UnLockPlayer();
            AttackSpawnerGO.GetComponent<AttackSpawnerScript>().SpawnAllowCall();
            //ScoreCounterGO.GetComponent<GameWinScript>().CheckAllScores();
            Debug.Log("Score compare ");
            RedQueenGO.GetComponent<RedQueenScript>().DanceStop();
            TracksGO.SetActive(false);
            curtainGO.GetComponent<CurtainRaiseScript>().CurtainRaise(); //Raises curtain

        }

       

    }



    ///https://www.youtube.com/watch?v=J03p5l2V64I
    ///
    #endregion

}

