using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{

    public GameObject HowToPlay_Menu;
    public GameObject HTPMenu;
    public GameObject InGameHTPMenu;
    public GameObject MainMenu;
    public GameObject HTPSlide1;
    public GameObject HTPSlide2;
    public GameObject HTPSlide3;
    public GameObject HTPSlide4;
    public GameObject HTPSlide5;
    public GameObject HTPSlide6;




  


    public void HowToPlayOpen()
    {
        // SceneManager.LoadScene("SettingsMenu");
        //HowToPlayMenu.SetActive(true);
        //MainMenu.SetActive(false);
        Debug.Log("Calling how to play menu");
        HTPMenu.SetActive(true);

    }




    public void Slide1Open()
    {

        HTPSlide1.SetActive(true);
        HTPSlide2.SetActive(false);
       
    }

    public void Slide2Open()
    {

        HTPSlide2.SetActive(true);
        HTPSlide3.SetActive(false);
       
    }

    public void Slide3Open()
    {
        HTPSlide2.SetActive(false);
        HTPSlide3.SetActive(true);
       

    }

    public void Slide4Open()
    {
        HTPSlide3.SetActive(false);
        HTPSlide4.SetActive(true);
        HTPSlide5.SetActive(false);

    }

    public void Slide5Open()
    {

        HTPSlide5.SetActive(true);
        HTPSlide4.SetActive(false);

    }

    public void Slide6Open()
    {
        HTPSlide6.SetActive(true);
        HTPSlide5.SetActive(false);

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
       

    }

    public void QuitGame()
    {

        Application.Quit();
        Debug.Log("Player has quit game");
    }
}
