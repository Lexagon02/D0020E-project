using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class PauseMenu : MonoBehaviour
{

   public static bool isGamePaused = false;

    public GameObject pauseMenu;

   

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
        //pauseMenu.GetComponent<SaveScript>().LoadFile();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
       

    }

    public void Home()
   {
        //pauseMenu.GetComponent<SaveScript>().SaveFile(currentScore, currentName);
        SceneManager.LoadScene("Start menu");
        Time.timeScale = 1;
        isGamePaused = false;
        GameManager.ScoreCount = 0;
        GameManager.ScoreBonus = 0;
    }

   

   public void Restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        isGamePaused = false;
        GameManager.ScoreCount = 0;
        GameManager.ScoreBonus = 0;
    }

    
}
