using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

   public static bool isGamePaused = false;

    public GameObject pauseMenu;
    public GameObject exitMenu;
    public GameObject nameMenu;


    public void Update() // Check for escape key
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause() // pause the game and music
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void Resume() // resume the game and music
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
       

    }

    public void Home() // go to extiMenu
   {
        pauseMenu.SetActive(false);
        exitMenu.SetActive(true);
    }

   

   public void Restart() // restart the level
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        isGamePaused = false;
        GameManager.ScoreBonus = 0;  //Resets the score
        GameManager.ScoreSum = 0;  //Resets the score
    }

    public void goHome() // go to start menu
    {
        SceneManager.LoadScene("Start menu");
        Time.timeScale = 1;
        isGamePaused = false;
        GameManager.ScoreBonus = 0; //Resets the score
        GameManager.ScoreSum = 0;  //Resets the score
    }

    public void Save() // go to name menu page
    {
        exitMenu.SetActive(false);
        nameMenu.SetActive(true);
        
    }

    private string s;
    public void ReadStringInput(string input) // Save your name to the highscore list
    {
            s = input;
            UnityEngine.Debug.Log(input);
            pauseMenu.GetComponent<Highscore>().AddHighscoreEntry(GameManager.ScoreSum, input, PlayerPrefs.GetInt("Difficulty"));
            nameMenu.SetActive(false);
            goHome();

    }
}
