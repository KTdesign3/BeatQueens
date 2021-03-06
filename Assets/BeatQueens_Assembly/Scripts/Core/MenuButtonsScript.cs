using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject MainMenu;
    public GameObject HowToPlayMenu;
    public GameObject HTPMenu;
    public GameObject InGameHTPMenu;
    public GameObject HTPSlide1;
    public GameObject HTPSlide2;
    public GameObject HTPSlide3;
    public GameObject HTPSlide4;
    public GameObject HTPSlide5;
    public GameObject HTPSlide6;
    public GameObject BeatQueensLogo;



    /* void start()
     {
         SceneManager.LoadScene("BeatQueensSplashScreen");
     } */
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Gets scene that comes immediately after this one in the build index
        Debug.Log("Player has started game");

    }

    public void SettingsMenuOpen()
    {
       // SceneManager.LoadScene("SettingsMenu");
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
        Debug.Log("Calling settings menu");

    }


    public void HowToPlayOpen()
    {
        // SceneManager.LoadScene("SettingsMenu");
        HowToPlayMenu.SetActive(true);
        MainMenu.SetActive(false);
        Debug.Log("Calling how to play menu");
        BeatQueensLogo.SetActive(false);

    }

    public void Slide1Open()
    {

        HTPSlide1.SetActive(true);
        HTPSlide2.SetActive(false);
        BeatQueensLogo.SetActive(false);

    }

    public void Slide2Open()
    {

        HTPSlide2.SetActive(true);
        HTPSlide3.SetActive(false);
        BeatQueensLogo.SetActive(false);

    }

    public void Slide3Open()
    {
        HTPSlide2.SetActive(false);
        HTPSlide3.SetActive(true);
        BeatQueensLogo.SetActive(false);


    }

    public void Slide4Open()
    {
        HTPSlide3.SetActive(false);
        HTPSlide4.SetActive(true);
        HTPSlide5.SetActive(false);
        BeatQueensLogo.SetActive(false);
    }

    public void Slide5Open()
    {

        HTPSlide5.SetActive(true);
        HTPSlide4.SetActive(false);
        BeatQueensLogo.SetActive(false);
    }

    public void Slide6Open()
    {
        HTPSlide6.SetActive(true);
        HTPSlide5.SetActive(false);
        BeatQueensLogo.SetActive(false);
    }

 
    public void Slide1Close()
    {
        HTPSlide1.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Slide2Close()
    {
        HTPSlide1.SetActive(true);
        HTPSlide2.SetActive(false);
    }

    public void Slide3Close()
    {
        HTPSlide1.SetActive(false);
        HTPSlide2.SetActive(true);
        HTPSlide3.SetActive(false);
    }

    public void Slide4Close()
    {
        HTPSlide2.SetActive(false);
        HTPSlide3.SetActive(true);
        HTPSlide4.SetActive(false);
    }

    public void Slide5Close()
    {
        HTPSlide3.SetActive(false);
        HTPSlide4.SetActive(true);
        HTPSlide5.SetActive(false);
    }

    public void Slide6Close()
    {
        HTPSlide4.SetActive(false);
        HTPSlide5.SetActive(true);
        HTPSlide6.SetActive(false);
       
    }

    public void SlideAllClose()
    {
        
        HTPSlide1.SetActive(false);
        HTPSlide2.SetActive(false);
        HTPSlide3.SetActive(false);
        HTPSlide4.SetActive(false);
        HTPSlide5.SetActive(false);
        HTPSlide6.SetActive(false);
        MainMenu.SetActive(true);
        BeatQueensLogo.SetActive(true);
    }

    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Player has quit game");
    }
}
