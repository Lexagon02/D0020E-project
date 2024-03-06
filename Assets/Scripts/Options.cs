using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    private float menuMusic;
    private float gameMusic;
    private float gameSound;
    public Slider menuMusicSlider;
    public Slider gameMusicSlider;
    public Slider gameSoundSlider;

    // Start is called before the first frame update
    void Awake()
    {
        //Set sliders to saved values, or default them to 50
        if (PlayerPrefs.GetFloat("menuMusic") == null) { menuMusic = 50f;}
        else { menuMusic = PlayerPrefs.GetFloat("menuMusic");}

        if (PlayerPrefs.GetFloat("gameMusic") == null){gameMusic = 50f;}
        else{gameMusic = PlayerPrefs.GetFloat("gameMusic");}

        if (PlayerPrefs.GetFloat("gameSound") == null){ gameSound = 50f;}
        else{ gameSound = PlayerPrefs.GetFloat("gameSound");};

        menuMusicSlider.value = menuMusic;
        gameMusicSlider.value = gameMusic;
        gameSoundSlider.value = gameSound;
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
        GameObject music = GameObject.FindGameObjectWithTag("menuMusic");
        music.GetComponent<MenuMusic>().changeVolume();
    }
}
