using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void Start()
    {
        PlayerPrefs.SetInt("difficulty", 0);
    }

    public void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Easy(){
        SceneManager.LoadScene("Main Easy");
        PlayerPrefs.SetInt("Difficulty",1);
    }

    public void Medium(){
        SceneManager.LoadScene("Main Easy");
        PlayerPrefs.SetInt("Difficulty", 2);
    }

    public void Hard(){
        SceneManager.LoadScene("Main Easy");
        PlayerPrefs.SetInt("Difficulty", 3);
    }
    public void Highscore()
    {
        SceneManager.LoadScene("Highscore");
    }
    public void StopMusic()
    {
        GameObject music = GameObject.FindGameObjectWithTag("menuMusic");
        print(music);
        DestroyObject(music);
        print("stop");
       
    }



    public void Quit() {
    #if UNITY_STANDALONE
        UnityEngine.Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
}
}
