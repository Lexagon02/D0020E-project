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


    public void Update()
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

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
       

    }

    public void Home()
   {
        pauseMenu.SetActive(false);
        exitMenu.SetActive(true);
    }

   

   public void Restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        isGamePaused = false;
        GameManager.ScoreCount = 0;
        GameManager.ScoreBonus = 0;
    }

    public void goHome()
    {
        SceneManager.LoadScene("Start menu");
        Time.timeScale = 1;
        isGamePaused = false;
        GameManager.ScoreCount = 0;
        GameManager.ScoreBonus = 0;
    }

    public void Save()
    {
        exitMenu.SetActive(false);
        nameMenu.SetActive(true);
        
    }

    private string s;
    public void ReadStringInput(string input)
    {
            s = input;
            UnityEngine.Debug.Log(input);
            pauseMenu.GetComponent<Highscore>().AddHighscoreEntry(GameManager.ScoreCount, input, PlayerPrefs.GetInt("Difficulty"));
            nameMenu.SetActive(false);
            goHome();

    }
}
