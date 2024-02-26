using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    private float menuMusic;
    private float gameMusic;
    private float gameSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void changeGameSound(float newValue)
    {
        gameSound= newValue;
        PlayerPrefs.SetFloat("gameSound", newValue);
    }
    public void changeGameMusic(float newValue)
    {
        gameMusic = newValue;
        PlayerPrefs.SetFloat("gameMusic", newValue);
    }
    public void changeMenuMusic(float newValue)
    {
        menuMusic = newValue;
        PlayerPrefs.SetFloat("menuMusic", newValue);
    }
}
