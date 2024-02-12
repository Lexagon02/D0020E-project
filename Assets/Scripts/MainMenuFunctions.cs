using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

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



    public void Quit() {
    #if UNITY_STANDALONE
        Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
}
}
